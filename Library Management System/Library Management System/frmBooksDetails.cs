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
    public partial class frmBooksDetails : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public frmBooksDetails()
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
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from tblBook",cn);
            dr = cm.ExecuteReader();
            while(dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i,dr["isbn"].ToString(),dr["booktitle"].ToString(),dr["publicationyear"].ToString(),dr["language"].ToString(),dr["category"].ToString(),dr["noofcopies"].ToString(),dr["currentcopies"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if(colName=="Edit")
            {
                frmBookAdd frm = new frmBookAdd(this);
                frm.btnCancel.Enabled = false;
                frm.btnUpdate.Enabled = true;
                frm.txtISBN.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.txtBookTitle.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                frm.txtPublicationYear.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                frm.txtLanguage.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                frm.txtCategory.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                frm.txtNoOfCopies.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                frm.txtCurrentCopies.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                frm.ShowDialog();

            }
            else if(colName=="Delete")
            {
                if(MessageBox.Show("Are you sure you want to delete this record?","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from tblBook where isbn like'"+dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()+"'",cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    LoadRecord();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmBookAdd frm = new frmBookAdd(this);
            frm.ShowDialog();
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
            SearchHere();
        }

        public void SearchHere()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from tblBook where isbn like '"+txtSearch.Text+"'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            cn.Close();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged_1(object sender, EventArgs e)
        {

        }
        private void SearchText()
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblBook where isbn like'" + txtSearch.Text + "' order by isbn", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i += 1;
                    dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchText();
            if(txtSearch.Text==String.Empty)
            {
                LoadRecord();
            }
        }
    }
}
