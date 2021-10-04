using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib
{
    public class MajorsController
    {
        public List<Major> GetAll()
        {
            var connStr = "server=localhost\\sqlexpress;database=EdDb;trusted_connection=true;";
            var sqlConn = new SqlConnection(connStr);
            sqlConn.Open();
            
            if(sqlConn.State != System.Data.ConnectionState.Open)
            {
                throw new Exception("Connection failed to open!");
            }
            var sql = ("Select * from Major;");
            var cmd = new SqlCommand(sql, sqlConn);
            var majors = new List<Major>();
            var reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
                var major = new Major()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Code = Convert.ToString(reader["Code"]),
                    Description = Convert.ToString(reader["Description"]),
                    MinSAT = Convert.ToInt32(reader["MinSAT"])
                };
                majors.Add(major);
            }
            reader.Close();
            sqlConn.Close();
            return majors;
        }
    }
}
