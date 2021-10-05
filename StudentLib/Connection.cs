
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib
{
    public class Connection
    {
        public SqlConnection SqlConnection { get; set; }
        public string ConnectionString { get; set; }

        public void Open()
        {
            SqlConnection = new SqlConnection(ConnectionString);
            SqlConnection.Open();
            if(SqlConnection.State != System.Data.ConnectionState.Open)
            {
                throw new Exception("Connection failed to open");
            }
        }
        public void Close() 
        {
            if (SqlConnection != null || SqlConnection.State == System.Data.ConnectionState.Open)
            {
                SqlConnection.Close();
            }
        }

        public Connection(string connectionString)
        {
            ConnectionString = connectionString;
        }


    }
}
