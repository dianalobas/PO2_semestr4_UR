using SMSProject.Data;
using System;
using System.Windows.Controls;

namespace SMSProject.Views
{
    public partial class StatisticsView : UserControl
    {
        private StudentRepository studentRepository = new StudentRepository();
        private CourseRepository  courseRepository  = new CourseRepository();
        private ResultRepository  resultRepository  = new ResultRepository();

        public StatisticsView()
        {
            InitializeComponent();
        }

        private void calcButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var students = studentRepository.GetAllStudents();
                var courses  = courseRepository.GetAllCourses();
                var results  = resultRepository.GetAllResults();
                double avg   = resultRepository.GetAverageGrade();

                statsStudentCount.Text = students.Count.ToString();
                statsCourseCount.Text  = courses.Count.ToString();
                statsAvgGrade.Text     = avg.ToString("F2");
                statsResultCount.Text  = results.Count.ToString();

                statsDetailText.Text =
                    $"Łącznie studentów: {students.Count}\n" +
                    $"  - Mężczyzn: {studentRepository.GetMaleCount()}\n" +
                    $"  - Kobiet:   {studentRepository.GetFemaleCount()}\n\n" +
                    $"Łącznie kursów:  {courses.Count}\n" +
                    $"Łącznie wyników: {results.Count}\n" +
                    $"Średnia ocen:    {avg:F2}";
            }
            catch (Exception ex)
            {
                statsDetailText.Text = "Błąd: " + ex.Message;
            }
        }

        private void clearStatsButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            statsStudentCount.Text = "0";
            statsCourseCount.Text  = "0";
            statsAvgGrade.Text     = "0.00";
            statsResultCount.Text  = "0";
            statsDetailText.Text   = "Kliknij 'Oblicz' aby zobaczyć zestawienie.";
        }
    }
}
