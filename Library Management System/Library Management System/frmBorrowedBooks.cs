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
    public partial class frmBorrowedBooks : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public frmBorrowedBooks()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyCon());
            LoadRecord();
        }

        private void frmBorrowedBooks_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadRecord()
        {
            int i=0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from tblBorrowedBooks", cn);
            dr = cm.ExecuteReader();
            while(dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dr["sname"].ToString(), dr["bname"].ToString(), dr["isbn"].ToString(), dr["sdate"].ToString(), dr["commitdate"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
