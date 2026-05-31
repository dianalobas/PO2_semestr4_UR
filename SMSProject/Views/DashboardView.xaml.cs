using SMSProject.Data;
using System;
using System.Windows.Controls;

namespace SMSProject.Views
{
    public partial class DashboardView : UserControl
    {
        private StudentRepository studentRepository = new StudentRepository();
        private CourseRepository  courseRepository  = new CourseRepository();
        private ResultRepository  resultRepository  = new ResultRepository();

        public DashboardView()
        {
            InitializeComponent();
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                var students = studentRepository.GetAllStudents();
                var courses  = courseRepository.GetAllCourses();
                var results  = resultRepository.GetAllResults();

                totalStudentsText.Text = students.Count.ToString();
                totalCoursesText.Text  = courses.Count.ToString();
                totalResultsText.Text  = results.Count.ToString();
                avgGradeText.Text      = resultRepository.GetAverageGrade().ToString("F2");

                femaleCountText.Text = studentRepository.GetFemaleCount().ToString();
                maleCountText.Text   = studentRepository.GetMaleCount().ToString();

                // Ostatnio dodani (top 5)
                recentStudentsGrid.ItemsSource = students.Count > 5
                    ? students.GetRange(students.Count - 5, 5)
                    : students;
            }
            catch (Exception)
            {
                // Jeśli brak połączenia z DB, zostają zera
            }
        }
    }
}
