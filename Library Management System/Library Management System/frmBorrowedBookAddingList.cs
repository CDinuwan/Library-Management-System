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
    public partial class frmBorrowedBookAddingList : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        frmBorrowedBooks frm = new frmBorrowedBooks();

        public frmBorrowedBookAddingList(frmBorrowedBooks f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyCon());
            LoadBooks();
            frm = f;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadBooks()
        {
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select isbn,booktitle,author,publicationyear,language from tblBook", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr["isbn"].ToString(), dr["booktitle"].ToString(),dr["author"].ToString(),dr["publicationyear"].ToString(), dr["language"].ToString());
            }
            dr.Close();
            cn.Close();
        }
        public void SearchBook()
        {
            try
            {
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select isbn,booktitle,author,publicationyear,language from tblBook where isbn like'" + txtSearch.Text + "' order by isbn", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["isbn"].ToString(), dr["booktitle"].ToString(),dr["author"].ToString(), dr["publicationyear"].ToString(), dr["language"].ToString());
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
            SearchBook();
            if (txtSearch.Text == String.Empty)
            {
                LoadBooks();
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmBorrowedBookAddingList_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Sel")
            {
                if (frm.txtBorrowerName.Text == String.Empty)
                {
                    MessageBox.Show("Please fill the borrower name!", "Fill Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to add this book?", "Adding", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("insert into tblBorrowedBooks(sname,author,bname,isbn,sdate,commitdate)values(@sname,@author,@bname,@isbn,@sdate,@commitdate)", cn);
                        cm.Parameters.AddWithValue("@sname", frm.txtBorrowerName.Text);
                        cm.Parameters.AddWithValue("@author", dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        cm.Parameters.AddWithValue("@bname", dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                        cm.Parameters.AddWithValue("@isbn", dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                        cm.Parameters.AddWithValue("@sdate", frm.dateTimePicker1.Value.ToString());
                        cm.Parameters.AddWithValue("@commitdate", frm.dateTimePicker2.Value.ToString());
                        cm.ExecuteNonQuery();
                        cn.Close();

                        MessageBox.Show("Your book is successfully added", "Confrimation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                        frm.LoadRecord();
                    }
                }

            }
        }
    }
}
