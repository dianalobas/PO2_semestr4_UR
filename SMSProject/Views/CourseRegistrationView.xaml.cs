using SMSProject.Data;
using SMSProject.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SMSProject.Views
{
    public partial class CourseRegistrationView : UserControl
    {
        private CourseRepository courseRepository = new CourseRepository();

        public CourseRegistrationView()
        {
            InitializeComponent();
        }

        private void saveCourseButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(courseNameTextBox.Text))
            { MessageBox.Show("Uzupełnij nazwę kursu."); return; }
            if (ectsComboBox.SelectedItem == null)
            { MessageBox.Show("Wybierz liczbę punktów ECTS."); return; }
            if (semesterComboBox.SelectedItem == null)
            { MessageBox.Show("Wybierz semestr."); return; }
            if (string.IsNullOrWhiteSpace(lecturerTextBox.Text))
            { MessageBox.Show("Uzupełnij prowadzącego."); return; }

            try
            {
                Course course = new Course
                {
                    CourseName = courseNameTextBox.Text.Trim(),
                    Ects       = int.Parse((ectsComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "0"),
                    Semester   = (semesterComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "",
                    Lecturer   = lecturerTextBox.Text.Trim()
                };

                courseRepository.AddCourse(course);
                MessageBox.Show("Kurs został zapisany pomyślnie.", "Sukces",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd zapisu: " + ex.Message, "Błąd",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void clearCourseButton_Click(object sender, RoutedEventArgs e) => ClearForm();
        private void cancelCourseButton_Click(object sender, RoutedEventArgs e) => ClearForm();

        private void ClearForm()
        {
            courseNameTextBox.Clear();
            ectsComboBox.SelectedIndex     = -1;
            semesterComboBox.SelectedIndex = -1;
            lecturerTextBox.Clear();
        }
    }
}
