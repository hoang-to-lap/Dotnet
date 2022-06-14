using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myproject
{
     class Connection
    {
        private static string stringConnection = @"Data Source=LAPTOP-7GN4S0AE\SQLEXPRESS;Initial Catalog=DuLieu;Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
