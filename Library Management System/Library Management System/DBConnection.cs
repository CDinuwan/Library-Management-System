using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;

namespace Library_Management_System
{
    class DBConnection
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        private int getTotalBook;
        private string con;
        public string MyCon()
        {
            con = @"Data Source=DESKTOP-OUGSDHL\SQLEXPRESS;Initial Catalog=LibraryMS;Integrated Security=True";
            return con;
        }
        public int GetTotalBooks()
        {
            cn = new SqlConnection();
            cn.ConnectionString = MyCon();
            cn.Open();
            cm = new SqlCommand("select isnull(sum(noofcopies),0) as noofcopies from tblBook",cn);
            getTotalBook = Int32.Parse(cm.ExecuteScalar().ToString());
            cn.Close();
            return getTotalBook;
        }
    }
}
