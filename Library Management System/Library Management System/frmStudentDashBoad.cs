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
    public partial class frmStudentDashBoad : Form
    {
        public frmStudentDashBoad()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Menu.Width==300)
            {
                Menu.Width = 60;
            }
            else
            {
                Menu.Width = 300;
            }
        }

        private void frmStudentDashBoad_Load(object sender, EventArgs e)
        {
            Menu.Width = 60;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
