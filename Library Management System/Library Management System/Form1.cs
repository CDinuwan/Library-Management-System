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
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        public Form1()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyCon());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            frmBooksDetails frm = new frmBooksDetails();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentDetails frm = new StudentDetails();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tblUser frm = new tblUser();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void btnissue_Click(object sender, EventArgs e)
        {
            frmDashBoad frm = new frmDashBoad();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmDashBoad frm = new frmDashBoad();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmBorrowedBooks frm = new frmBorrowedBooks();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
