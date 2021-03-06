﻿using System;
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
                dataGridView1.Rows.Add(i, dr["sname"].ToString(),dr["author"].ToString(), dr["bname"].ToString(), dr["isbn"].ToString(), dr["sdate"].ToString(), dr["commitdate"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dataGridView1.Columns[e.ColumnIndex].Name;
                if(colName=="Delete")
                {
                    if (MessageBox.Show("Are you sure you want to delete this record ?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tblBorrowedBooks where sname like'" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Your message has been successfully deleted!", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRecord();
                    }
                }
                
            }catch(Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchText();
            if (txtSearch.Text == String.Empty)
            {
                LoadRecord();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            frmBorrowedBookAddingList frm = new frmBorrowedBookAddingList(this);
            frm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            frmStudentAddingList frm = new frmStudentAddingList();
            frm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();    
        }
        public void Clear()
        {
            dataGridView1.Rows.Clear();
            txtBorrowerName.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Staff_Details frm = new Staff_Details();
            frm.ShowDialog();
        }
        public void SearchText()
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblBorrowedBooks where isbn like'"+txtSearch.Text+"'",cn);
                dr = cm.ExecuteReader();
                while(dr.Read())
                {
                    i += 1;
                    dataGridView1.Rows.Add(i, dr["sname"].ToString(),dr["author"].ToString(), dr["bname"].ToString(), dr["isbn"].ToString(), dr["sdate"].ToString(), dr["commitdate"].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
