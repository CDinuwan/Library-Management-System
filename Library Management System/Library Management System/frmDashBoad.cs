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
using System.Windows.Forms.DataVisualization.Charting;

namespace Library_Management_System
{
    public partial class frmDashBoad : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        public frmDashBoad()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyCon());
            LoadRecord();
        }

        private void frmDashBoad_Resize(object sender, EventArgs e)
        {
            panel1.Left = (this.Width - panel1.Width) / 2;
        }

        private void frmDashBoad_Load(object sender, EventArgs e)
        {

            label1.Text = dbcon.GetTotalBooks().ToString();
            lblTotalStudents.Text = dbcon.StudentCount().ToString();
            lblStaffCount.Text = dbcon.StaffCount().ToString();
            lblBorrowedBook.Text = dbcon.BorrowedBookCount().ToString();
        }

        private void ll_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        public void LoadRecord()
        {
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select isnull(sum(noofcopies),0.0) as noofcopies,publicationyear from tblBook group by publicationyear", cn);
            DataSet ds = new DataSet();

            da.Fill(ds,"Books");
            chart1.DataSource = ds.Tables["Books"];
            Series series1 = chart1.Series["Series1"];
            series1.ChartType = SeriesChartType.Doughnut;

            series1.Name = "Total count of Books";
            var chart = chart1;
            chart.Series[series1.Name].XValueMember = "publicationyear";
            chart.Series[series1.Name].YValueMembers = "noofcopies";
            chart1.Series[0].IsValueShownAsLabel = true;
            cn.Close();
        }
    }
}
