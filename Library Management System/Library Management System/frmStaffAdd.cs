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
    
    public partial class frmStaffAdd : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        tblUser frm = new tblUser();
        public frmStaffAdd(tblUser f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyCon());
            frm = f;
        }
        public void Clear()
        {
            txtRefNo.Clear();
            txtAddress.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtRole.Clear();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Are you sure you want to save this record?","Confrimation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tblStaff(refno,name,role,address,phoneno)values(@refno,@name,@role,@address,@phoneno)", cn);
                    cm.Parameters.AddWithValue("@refno", txtRefNo.Text);
                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    cm.Parameters.AddWithValue("@role", txtRole.Text);
                    cm.Parameters.AddWithValue("@address", txtAddress.Text);
                    cm.Parameters.AddWithValue("phoneno", txtPhone.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    Clear();
                    MessageBox.Show("Your record has been successfully added");
                    this.Dispose();
                    frm.LoadRecord();
                }
            }
            catch(Exception er)
            {
                cn.Close();
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Are you sure you want to update this record?","Confrimation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("update tblUser set refno=@refno,name=@name,role=@role,address=@address,phoneno=@phoneno where refno like '" + txtRefNo.Text + "'", cn);
                    cm.Parameters.AddWithValue("@refno", txtRefNo.Text);
                    cm.Parameters.AddWithValue("@name", txtName.Text);
                    cm.Parameters.AddWithValue("@role", txtRole.Text);
                    cm.Parameters.AddWithValue("address", txtAddress.Text);
                    cm.Parameters.AddWithValue("@phoneno", txtPhone.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Your record has been successfully updated");
                    Clear();
                    frm.LoadRecord();
                }
            }catch(Exception er)
            {
                cn.Close();
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
