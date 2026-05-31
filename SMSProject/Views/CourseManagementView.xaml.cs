using SMSProject.Data;
using SMSProject.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SMSProject.Views
{
    public partial class CourseManagementView : UserControl
    {
        private CourseRepository courseRepository = new CourseRepository();

        public CourseManagementView()
        {
            InitializeComponent();
            LoadCourses();
        }

        private void LoadCourses()
        {
            try { coursesDataGrid.ItemsSource = courseRepository.GetAllCourses(); }
            catch (Exception ex)
            { MessageBox.Show("Błąd ładowania kursów: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void refreshCourseButton_Click(object sender, RoutedEventArgs e) => LoadCourses();

        private void searchCourseButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var all = courseRepository.GetAllCourses();
                string q = searchCourseTextBox.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(q))
                    all = all.Where(c => c.CourseName.ToLower().Contains(q)).ToList();
                coursesDataGrid.ItemsSource = all;
            }
            catch (Exception ex) { MessageBox.Show("Błąd: " + ex.Message); }
        }

        private void deleteCourseButton_Click(object sender, RoutedEventArgs e)
        {
            Course? c = coursesDataGrid.SelectedItem as Course;
            if (c == null) { MessageBox.Show("Wybierz kurs do usunięcia.", "Brak wyboru", MessageBoxButton.OK, MessageBoxImage.Warning); return; }

            if (MessageBox.Show("Czy na pewno chcesz usunąć wybrany kurs?", "Potwierdzenie",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try { courseRepository.DeleteCourse(c.CourseId); LoadCourses(); }
                catch (Exception ex) { MessageBox.Show("Błąd usuwania: " + ex.Message); }
            }
        }

        private void editCourseButton_Click(object sender, RoutedEventArgs e)
        {
            Course? c = coursesDataGrid.SelectedItem as Course;
            if (c == null) { MessageBox.Show("Wybierz kurs do edycji.", "Brak wyboru", MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            MessageBox.Show($"Edycja kursu: {c.CourseName}\n(funkcja do rozbudowy)", "Edycja");
        }

        private void detailsCourseButton_Click(object sender, RoutedEventArgs e)
        {
            Course? c = coursesDataGrid.SelectedItem as Course;
            if (c == null) { MessageBox.Show("Wybierz kurs.", "Brak wyboru", MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            MessageBox.Show($"ID: {c.CourseId}\nNazwa: {c.CourseName}\nECTS: {c.Ects}\nSemestr: {c.Semester}\nProwadzący: {c.Lecturer}", "Szczegóły kursu");
        }
    }
}
