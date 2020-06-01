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
    public partial class frmStudentAddingList : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public frmStudentAddingList()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyCon());
            LoadRecords();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadRecords()
        {
            dataGridView2.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select regno,name,phoneno from tblStudent",cn);
            dr = cm.ExecuteReader();
            while(dr.Read())
            {
                dataGridView2.Rows.Add(dr["regno"].ToString(), dr["name"].ToString(), dr["phoneno"].ToString());
            }
            dr.Close();
            cn.Close();
        }
        public void SearchText()
        {
            dataGridView2.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select regno,name,phoneno from tblStudent where regno like'"+txtSearch.Text+"'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                dataGridView2.Rows.Add(dr["regno"].ToString(), dr["name"].ToString(), dr["phoneno"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchText();
            if(txtSearch.Text==String.Empty)
            {
                LoadRecords();
            }
        }
    }
}
