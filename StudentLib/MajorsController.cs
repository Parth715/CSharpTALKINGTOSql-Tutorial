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
        private SqlConnection sqlConn { get; set; }
        public MajorsController(Connection connection)
        {
            sqlConn = connection.SqlConnection;
        }
        public int Create(Major major)
        {
            var sql = " Insert Major (Code, Description, MinSAT) " +
                $"Values ('{major.Code}', '{major.Description}', '{major.MinSAT}');";
            var cmd = new SqlCommand(sql, sqlConn);
            var rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected;
        }
        
        
        
        
        public int Change(Major major)
        {
            var sql = " update Major set " +
                " Code = @Code," +
                " Description = @Description, " +
                " MinSAT = @MinSAT " +
                " Where Id = @Id;";
            var cmd = new SqlCommand(sql, sqlConn);
            cmd.Parameters.AddWithValue("@Code", major.Code);
            cmd.Parameters.AddWithValue("@Description", major.Description);
            cmd.Parameters.AddWithValue("@MinSAT", major.MinSAT);
            cmd.Parameters.AddWithValue("@Id", major.Id);
            var rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected;
        }


        public int Delete(int Id)
        {
            var major = GetByPk(Id);
            if(major == null)
            {
                throw new Exception("Major not found");
            }
            var sql = " Delete major " +
                $" where Id = {Id};";
            var cmd = new SqlCommand(sql, sqlConn);
            var rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected;
        }





        public List<Major> GetAll()
        {
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
            
            return majors;
        }

        
        
        
        
        
        
        public Major? GetByPk(int Id)
        {
            var sql = $"Select * from Major where Id = @Id;";
            var cmd = new SqlCommand(sql, sqlConn);
            cmd.Parameters.AddWithValue("@Id", Id);
            var reader = cmd.ExecuteReader();
            if(!reader.HasRows)
            {

                reader.Close();
                return null;
            }
            reader.Read();
            var major = new Major()
            {
                Id = Convert.ToInt32(reader["Id"]),
                Code = Convert.ToString(reader["Code"]),
                Description = Convert.ToString(reader["Description"]),
                MinSAT = Convert.ToInt32(reader["MinSAT"])
            };

            reader.Close();

            return major;
        }
    }
}
