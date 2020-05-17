using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    class DBConnection
    {
        public string MyCon()
        {
            string con = @"Data Source=DESKTOP-OUGSDHL\SQLEXPRESS;Initial Catalog=LibraryMS;Integrated Security=True";
            return con;
        }
    }
}
