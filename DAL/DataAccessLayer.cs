using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;



namespace DAL
{
    public class DataAccessLayer
    {
        static string sConn = "Data Source = localhost; Initial Catalog = SchoolDB; Integrated Security = true; ";
        SqlConnection dbConn = new SqlConnection(sConn);
        SqlCommand dbComm;
        SqlDataAdapter dbAdapter;
        DataTable dt;

        public int InsertCourse(Course c)
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_InsertCourse", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Description", c.CourseDescription);
            dbComm.Parameters.AddWithValue("@Duration", c.Duration);
            dbComm.Parameters.AddWithValue("@Status", c.Status);
            dbComm.Parameters.AddWithValue("@CourseTypeID", c.CourseTypeID);

            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int UpdateCourse(Course c) 
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_UpdateCourse", dbConn);

            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@CourseID", c.CourseID);
            dbComm.Parameters.AddWithValue("@Status", c.Status);
            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int DeleteCourse(Course c)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_DeleteCourse", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@CourseID", c.CourseID);
            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public DataTable GetCourse()
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_GetCourse", dbConn);
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();
            return dt;
        }
        public DataTable GetCourseType()
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_GetCourseType", dbConn);
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();
            return dt;
        }
    }
}
