using SMSProject.Models;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace SMSProject.Data
{
    public class StudentRepository
    {
        private DBConnection dbConnection = new DBConnection();

        public void AddStudent(Student student)
        {
            string query = @"INSERT INTO Students
                             (FirstName, LastName, AlbumNumber, Email, Gender, GroupId)
                             VALUES
                             (@FirstName, @LastName, @AlbumNumber, @Email, @Gender, @GroupId)";

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@LastName", student.LastName);
                command.Parameters.AddWithValue("@AlbumNumber", student.AlbumNumber);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@Gender", student.Gender);
                command.Parameters.AddWithValue("@GroupId", student.GroupId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            string query = "SELECT StudentId, FirstName, LastName, AlbumNumber, Email, Gender, GroupId FROM Students";

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student
                    {
                        StudentId   = (int)reader["StudentId"],
                        FirstName   = reader["FirstName"].ToString()!,
                        LastName    = reader["LastName"].ToString()!,
                        AlbumNumber = reader["AlbumNumber"].ToString()!,
                        Email       = reader["Email"].ToString()!,
                        Gender      = reader["Gender"].ToString()!,
                        GroupId     = (int)reader["GroupId"]
                    };
                    students.Add(student);
                }
            }
            return students;
        }

        public void DeleteStudent(int studentId)
        {
            string query = "DELETE FROM Students WHERE StudentId = @StudentId";

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentId", studentId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public int GetMaleCount()
        {
            string query = "SELECT COUNT(*) FROM Students WHERE Gender = 'Mężczyzna'";
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public int GetFemaleCount()
        {
            string query = "SELECT COUNT(*) FROM Students WHERE Gender = 'Kobieta'";
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }
    }
}
