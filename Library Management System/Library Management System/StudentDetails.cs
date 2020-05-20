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
    
    public partial class StudentDetails : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public StudentDetails()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyCon());
            LoadRecord();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if(colName=="Edit")
            {
                frmStudentAdd frm = new frmStudentAdd(this);
                frm.txtRegno.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                frm.txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.txtBirthDay.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                frm.txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                frm.txtPhoneno.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                frm.ShowDialog();
            }
            else if(colName=="Delete")
            {
                cn.Open();
                cm = new SqlCommand("delete from tblStudent where regno like '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'",cn);
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Your record has been successfully deleted.");
                LoadRecord();
            }
        }
        public void LoadRecord()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("Select * from tblStudent", cn);
            dr = cm.ExecuteReader();
            while(dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(dr["regno"].ToString(), dr["name"].ToString(), dr["birthday"].ToString(), dr["address"].ToString(), dr["phoneno"].ToString());
            }
            cn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmStudentAdd frm = new frmStudentAdd(this);
            frm.ShowDialog();
        }
    }
}
