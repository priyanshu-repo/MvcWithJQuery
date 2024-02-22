using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace MvcWithJQuery.Models
{
    public sealed class ContextDb
    {
        #region Singleton
        private static ContextDb Instance = null;
        public static ContextDb GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ContextDb();
            }
            return Instance;
        }
        private ContextDb()
        {

        }
        #endregion

        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public List<Student> GetStudents()
        {
            List<Student> list = new List<Student>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = str;
                using (SqlCommand cmd= new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Students";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach(DataRow dr in dt.Rows)
                    {
                        list.Add(new Student
                        {
                            Id = (int)dr["Id"],
                            Name = dr["Name"].ToString(),
                            Age = (int)dr["Age"]
                        });
                    }
                    return list;
                }
            }
        }


        public Student GetSingleStudent(int Id)
        {
            Student student= new Student();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = str;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Students where Id='"+Id+"'";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                      student.Id= (int)dr["Id"];    
                        student.Name= dr["Name"].ToString();
                        student.Age= (int)dr["Age"];  
                    }
                    return student;
                }
            }
        }

        public void InsertStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = str;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Students values('" + student.Name + "','" + student.Age + "')";
                    cmd.Connection = con;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = str;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update Students set Name='"+student.Name+"',Age='"+student.Age+"' where Id='"+student.Id+"'";
                    cmd.Connection = con;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void DeleteStudent(int id)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = str;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from Students where id='" + id + "'";
                    cmd.Connection = con;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

    }
}