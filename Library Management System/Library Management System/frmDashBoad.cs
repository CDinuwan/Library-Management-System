using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class frmDashBoad : Form
    {
        DBConnection dbcon = new DBConnection();
        public frmDashBoad()
        {
            InitializeComponent();
        }

        private void frmDashBoad_Resize(object sender, EventArgs e)
        {
            panel1.Left = (this.Width - panel1.Width) / 2;
        }

        private void frmDashBoad_Load(object sender, EventArgs e)
        {

            label1.Text = dbcon.GetTotalBooks().ToString();
        }

        private void ll_Click(object sender, EventArgs e)
        {

        }
    }
}
