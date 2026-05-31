using SMSProject.Data;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SMSProject.Views
{
    public partial class CoursePrintView : UserControl
    {
        private CourseRepository courseRepository = new CourseRepository();
        public CoursePrintView() { InitializeComponent(); LoadCourses(); }
        private void LoadCourses()
        {
            try { printCoursesGrid.ItemsSource = courseRepository.GetAllCourses(); }
            catch (Exception ex) { MessageBox.Show("Błąd: " + ex.Message); }
        }
        private void refreshButton_Click(object sender, RoutedEventArgs e) => LoadCourses();
        private void printButton_Click(object sender, RoutedEventArgs e)
            => MessageBox.Show("Funkcja drukowania do rozbudowy.", "Drukuj");
    }
}
