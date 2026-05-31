using SMSProject.Models;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace SMSProject.Data
{
    public class ResultRepository
    {
        private DBConnection dbConnection = new DBConnection();

        public void AddResult(Result result)
        {
            string query = @"INSERT INTO Results (StudentId, CourseId, Grade, DateAdded)
                             VALUES (@StudentId, @CourseId, @Grade, @DateAdded)";

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentId", result.StudentId);
                command.Parameters.AddWithValue("@CourseId",  result.CourseId);
                command.Parameters.AddWithValue("@Grade",     result.Grade);
                command.Parameters.AddWithValue("@DateAdded", result.DateAdded);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Result> GetAllResults()
        {
            List<Result> results = new List<Result>();
            string query = @"SELECT r.ResultId, r.StudentId, r.CourseId, r.Grade, r.DateAdded,
                                    s.FirstName + ' ' + s.LastName AS StudentName,
                                    c.CourseName
                             FROM Results r
                             JOIN Students s ON r.StudentId = s.StudentId
                             JOIN Courses  c ON r.CourseId  = c.CourseId";

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new Result
                    {
                        ResultId    = (int)reader["ResultId"],
                        StudentId   = (int)reader["StudentId"],
                        CourseId    = (int)reader["CourseId"],
                        Grade       = reader["Grade"].ToString()!,
                        DateAdded   = (System.DateTime)reader["DateAdded"],
                        StudentName = reader["StudentName"].ToString()!,
                        CourseName  = reader["CourseName"].ToString()!
                    });
                }
            }
            return results;
        }

        public void UpdateResult(Result result)
        {
            string query = @"UPDATE Results SET StudentId=@StudentId, CourseId=@CourseId,
                             Grade=@Grade, DateAdded=@DateAdded WHERE ResultId=@ResultId";

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ResultId",  result.ResultId);
                command.Parameters.AddWithValue("@StudentId", result.StudentId);
                command.Parameters.AddWithValue("@CourseId",  result.CourseId);
                command.Parameters.AddWithValue("@Grade",     result.Grade);
                command.Parameters.AddWithValue("@DateAdded", result.DateAdded);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteResult(int resultId)
        {
            string query = "DELETE FROM Results WHERE ResultId = @ResultId";
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ResultId", resultId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public double GetAverageGrade()
        {
            string query = "SELECT AVG(CAST(Grade AS FLOAT)) FROM Results WHERE ISNUMERIC(Grade) = 1";
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                object result = command.ExecuteScalar();
                return result == System.DBNull.Value ? 0.0 : (double)result;
            }
        }
    }
}
