using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class Staff_Details : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public Staff_Details()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyCon());
            LoadRecord();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void LoadRecord()
        {
            dataGridView2.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select refno,name,role,phoneno from tblStaff", cn);
            dr = cm.ExecuteReader();
            while(dr.Read())
            {
                dataGridView2.Rows.Add(dr["refno"].ToString(),dr["name"].ToString(),dr["role"].ToString(),dr["phoneno"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void SearchText()
        {
            dataGridView2.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select refno,name,role,phoneno from tblStaff where refno like '"+metroTextBox1.Text+"'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                dataGridView2.Rows.Add(dr["refno"].ToString(), dr["name"].ToString(), dr["role"].ToString(), dr["phoneno"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            SearchText();
            if(metroTextBox1.Text==String.Empty)
            {
                LoadRecord();
            }
        }
    }
}
