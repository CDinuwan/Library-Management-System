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
        public frmBorrowedBookAddingList()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyCon());
            LoadBooks();
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
            cm = new SqlCommand("select isbn,booktitle,publicationyear,language from tblBook", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr["isbn"].ToString(), dr["booktitle"].ToString(), dr["publicationyear"].ToString(), dr["language"].ToString());
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
                cm = new SqlCommand("select isbn,booktitle,publicationyear,language from tblBook where isbn like'" + txtSearch.Text + "' order by isbn", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
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

        }
    }
}
