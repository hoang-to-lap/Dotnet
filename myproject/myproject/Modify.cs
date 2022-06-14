using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myproject
{
     class Modify
    {
        public Modify()
        {

        }
        SqlDataAdapter dataAdapter;
        SqlCommand sqlCommand;
        public DataTable DataTable(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);

                sqlConnection.Close();
            }
            return dataTable;
        }
        public void Command(DuLieu duLieu, string query)
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@FileName", duLieu.FileName);
                sqlCommand.Parameters.Add("@Path", duLieu.Path);
                sqlCommand.Parameters.Add("@ASQTime", duLieu.ASQTime);
                sqlCommand.Parameters.Add("@UpdateTime", duLieu.Updatetime);
                sqlCommand.Parameters.Add("@Version", duLieu.Version);
                sqlCommand.Parameters.Add("@Anh", duLieu.Anh);
                sqlCommand.ExecuteNonQuery();


               sqlConnection.Close();
            }
        }
    }
}
