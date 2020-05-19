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
    public partial class frmStudentAdd : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        StudentDetails frm;
        public frmStudentAdd(StudentDetails f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyCon());
            frm = f;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Clear()
        {
            txtAddress.Clear();
            txtBirthDay.Clear();
            txtName.Clear();
            txtPhoneno.Clear();
            txtRegno.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Do you want to save this record ?","Question",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tblStudent(regno,name,birthday,address,phoneno)values(@regno,@name,@birthday,@address,@phoneno)", cn);
                    cm.Parameters.AddWithValue("@regno", txtRegno.Text);
                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    cm.Parameters.AddWithValue("@birthday", txtBirthDay.Text);
                    cm.Parameters.AddWithValue("@address", txtAddress.Text);
                    cm.Parameters.AddWithValue("@phoneno", txtPhoneno.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Your record has been saved");
                    this.Dispose();
                    Clear();
                    frm.LoadRecord();
                }
                
            }catch(Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this record?", "Question", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("update tblStudent set name=@name,birthday=@birthday,address=@address,phoneno=@phoneno where regno like'" + txtRegno.Text + "'", cn);
                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    cm.Parameters.AddWithValue("@birthday", txtBirthDay.Text);
                    cm.Parameters.AddWithValue("@address", txtAddress.Text);
                    cm.Parameters.AddWithValue("@phoneno", txtPhoneno.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Your record has been updated");
                    this.Dispose();
                    Clear();
                    frm.LoadRecord();
                }
            }catch(Exception er)
            {
                MessageBox.Show(er.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }


        private void frmStudentAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
