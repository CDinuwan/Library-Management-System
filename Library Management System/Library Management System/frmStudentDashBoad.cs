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
    public partial class frmStudentDashBoad : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public frmStudentDashBoad()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyCon());
            LoadRecord();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Menu.Width==300)
            {
                Menu.Width = 60;
            }
            else
            {
                Menu.Width = 300;
            }
        }

        private void frmStudentDashBoad_Load(object sender, EventArgs e)
        {
            Menu.Width = 60;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadRecord()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from tblBook", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dr["isbn"].ToString(), dr["booktitle"].ToString(),dr["author"].ToString(), dr["publicationyear"].ToString(), dr["language"].ToString(), dr["category"].ToString(), dr["noofcopies"].ToString());
            }
            dr.Close();
            cn.Close();
        }
        public void SearchText()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from tblBook where booktitle like'" + txtSearch.Text + "'", cn);
            dr = cm.ExecuteReader();
            while(dr.Read())
            { 
                {
                    i += 1;
                    dataGridView1.Rows.Add(i, dr["isbn"].ToString(), dr["booktitle"].ToString(), dr["publicationyear"].ToString(), dr["language"].ToString(), dr["category"].ToString(), dr["noofcopies"].ToString());
                }
            }
            dr.Close();
            cn.Close();
        }

        private void txtSearch_TabStopChanged(object sender, EventArgs e)
        {
           
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchText();
            if (txtSearch.Text == String.Empty)
            {
                LoadRecord();
            }
        }
    }
}
