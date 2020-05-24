using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class tblUser : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public tblUser()  
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyCon());
            LoadRecord();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadRecord()
        {
            int i = 0;
            dataGridView2.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from tblStaff", cn);
            dr = cm.ExecuteReader();
            while(dr.Read())
            {
                i += 1;
                dataGridView2.Rows.Add(i, dr["refno"].ToString(), dr["name"].ToString(), dr["role"].ToString(), dr["address"].ToString(), dr["phoneno"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView2.Columns[e.ColumnIndex].Name;
            try
            {
                if(colName=="Delete")
                {
                    if(MessageBox.Show("Are you sure you want to delete this record?","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tblStaff where refno like'" + dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Your Message has been successfully deleted");
                        LoadRecord();
                    }
                }
                else if(colName=="Edit")
                {
                    frmStaffAdd frm = new frmStaffAdd(this);
                    frm.btnCancel.Enabled = false;
                    frm.btnUpdate.Enabled = true;
                    frm.btnSave.Enabled = false;
                    frm.txtRefNo.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                    frm.txtName.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                    frm.txtRole.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                    frm.txtAddress.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                    frm.txtPhone.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                    frm.ShowDialog();
                }
            }catch(Exception er)
            {
                MessageBox.Show(er.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmStaffAdd frm = new frmStaffAdd(this);
            frm.ShowDialog();
        }
    }
}
