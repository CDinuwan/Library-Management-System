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
        public frmBookAdd(frmBooksDetails f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyCon());
            frm.LoadRecord();
            frm = f;
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
            btnCancel.Enabled=true;
            btnUpdate.Enabled = false;

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtISBN_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtBookTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtPublicationYear_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtLanguage_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtNoOfCopies_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtCurrentCopies_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this record?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("update tblBook set booktitle=@booktitle,publicationyear=@publicationyear,language=@language,category=@category,noofcopies=@noofcopies,currentcopies=@currentcopies where isbn like'"+txtISBN.Text+"'", cn);
                    cm.Parameters.AddWithValue("@booktitle", txtBookTitle.Text);
                    cm.Parameters.AddWithValue("@publicationyear", txtPublicationYear.Text);
                    cm.Parameters.AddWithValue("@language", txtLanguage.Text);
                    cm.Parameters.AddWithValue("@category", txtCategory.Text);
                    cm.Parameters.AddWithValue("@noofcopies", txtNoOfCopies.Text);
                    cm.Parameters.AddWithValue("@currentcopies", txtCurrentCopies.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("The record has been updated");
                    Clear();
                    frm.LoadRecord();
                    this.Dispose();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
