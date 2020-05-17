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
    public partial class frmBookAdd : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        frmBooksDetails frm = new frmBooksDetails();
        public frmBookAdd()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyCon());
            frm.LoadRecord();
        }

        private void frmBookAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            txtISBN.Clear();
            txtBookTitle.Clear();
            txtCategory.Clear();
            txtNoOfCopies.Clear();
            txtPublicationYear.Clear();
            txtCurrentCopies.Clear();
            txtLanguage.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Are you sure you want to save this record?","Save",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tblBook(isbn,booktitle,publicationyear,language,category,noofcopies,currentcopies)values(@isbn,@booktitle,@publicationyear,@language,@category,@noofcopies,@currentcopies)", cn);
                    cm.Parameters.AddWithValue("@isbn", txtISBN.Text);
                    cm.Parameters.AddWithValue("@booktitle", txtBookTitle.Text);
                    cm.Parameters.AddWithValue("@publicationyear", txtPublicationYear.Text);
                    cm.Parameters.AddWithValue("@language", txtLanguage.Text);
                    cm.Parameters.AddWithValue("@category", txtCategory.Text);
                    cm.Parameters.AddWithValue("@noofcopies", txtNoOfCopies.Text);
                    cm.Parameters.AddWithValue("@currentcopies", txtCurrentCopies.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("The record has been saved");
                    Clear();
                    frm.LoadRecord();
                }
            }catch(Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
