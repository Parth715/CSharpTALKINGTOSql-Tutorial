using Microsoft.Data.SqlClient;
using System;

namespace CSharp_Sql_Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var connStr = "server=localhost\\sqlexpress;database=EdDb;trusted_connection=true;";
            var sqlConn = new SqlConnection(connStr);
            sqlConn.Open();
            if(sqlConn.State != System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connection did not open");
                return;
            }
            Console.WriteLine("Connection opened");
            // continue sql here

            sqlConn.Close();
        }
    }
}
