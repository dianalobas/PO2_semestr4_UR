using SMSProject.Models;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace SMSProject.Data
{
    public class CourseRepository
    {
        private DBConnection dbConnection = new DBConnection();

        public void AddCourse(Course course)
        {
            string query = @"INSERT INTO Courses (CourseName, Ects, Semester, Lecturer)
                             VALUES (@CourseName, @Ects, @Semester, @Lecturer)";

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseName", course.CourseName);
                command.Parameters.AddWithValue("@Ects",       course.Ects);
                command.Parameters.AddWithValue("@Semester",   course.Semester);
                command.Parameters.AddWithValue("@Lecturer",   course.Lecturer);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            string query = "SELECT CourseId, CourseName, Ects, Semester, Lecturer FROM Courses";

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    courses.Add(new Course
                    {
                        CourseId   = (int)reader["CourseId"],
                        CourseName = reader["CourseName"].ToString()!,
                        Ects       = (int)reader["Ects"],
                        Semester   = reader["Semester"].ToString()!,
                        Lecturer   = reader["Lecturer"].ToString()!
                    });
                }
            }
            return courses;
        }

        public void UpdateCourse(Course course)
        {
            string query = @"UPDATE Courses SET CourseName=@CourseName, Ects=@Ects,
                             Semester=@Semester, Lecturer=@Lecturer WHERE CourseId=@CourseId";

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseId",   course.CourseId);
                command.Parameters.AddWithValue("@CourseName", course.CourseName);
                command.Parameters.AddWithValue("@Ects",       course.Ects);
                command.Parameters.AddWithValue("@Semester",   course.Semester);
                command.Parameters.AddWithValue("@Lecturer",   course.Lecturer);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCourse(int courseId)
        {
            string query = "DELETE FROM Courses WHERE CourseId = @CourseId";
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseId", courseId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
