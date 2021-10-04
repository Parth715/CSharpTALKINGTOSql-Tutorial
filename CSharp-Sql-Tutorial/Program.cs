using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using StudentLib;

namespace CSharp_Sql_Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var majorsCtrl = new MajorsController();
            var majors = majorsCtrl.GetAll();
            foreach(var major in majors)
            {
                Console.WriteLine(major);
            }
        }
        static void X() { 
            var connStr = "server=localhost\\sqlexpress;database=EdDb;trusted_connection=true;";
            var sqlConn = new SqlConnection(connStr);
            sqlConn.Open();
            if(sqlConn.State != System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connection did not open");
                return;
            }
            Console.WriteLine("Connection opened");

            var sql = "Select * from Student " +
                        "where GPA between 2.5 and 3.5 " +
                        "order by SAT desc;";
            var cmd = new SqlCommand(sql, sqlConn);
            var students = new List<Student>();
            var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                var student = new Student();
                student.Id = Convert.ToInt32(reader["Id"]); //SQL -> C# object -> C# int
                student.Firstname = reader["Firstname"].ToString();
                student.Lastname = Convert.ToString(reader["Lastname"]);
                student.StateCode = reader["StateCode"].ToString();
                student.SAT = reader["SAT"].Equals(DBNull.Value)//Is the value from SAT null?
                        ? (int?)null
                        : Convert.ToInt32(reader["SAT"]);//if value is int then convert to int
                student.GPA = Convert.ToDecimal(reader["GPA"]);
                student.MajorId = reader["MajorId"].Equals(DBNull.Value)
                        ? (int?)null
                        : Convert.ToInt32(reader["MajorId"]);
                Console.WriteLine(student);
                students.Add(student);
            }
            reader.Close();
            sqlConn.Close();

        }
    }
}
