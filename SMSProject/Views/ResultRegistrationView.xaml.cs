using SMSProject.Data;
using SMSProject.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SMSProject.Views
{
    public partial class ResultRegistrationView : UserControl
    {
        private ResultRepository  resultRepository  = new ResultRepository();
        private StudentRepository studentRepository = new StudentRepository();
        private CourseRepository  courseRepository  = new CourseRepository();

        public ResultRegistrationView()
        {
            InitializeComponent();
            LoadDropdowns();
        }

        private void LoadDropdowns()
        {
            try
            {
                studentComboBox.ItemsSource = studentRepository.GetAllStudents();
                courseComboBox.ItemsSource  = courseRepository.GetAllCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania danych: " + ex.Message);
            }
        }

        private void saveResultButton_Click(object sender, RoutedEventArgs e)
        {
            if (studentComboBox.SelectedItem == null) { MessageBox.Show("Wybierz studenta."); return; }
            if (courseComboBox.SelectedItem  == null) { MessageBox.Show("Wybierz kurs.");     return; }
            if (gradeComboBox.SelectedItem   == null) { MessageBox.Show("Wybierz ocenę.");    return; }

            try
            {
                Result result = new Result
                {
                    StudentId = ((Student)studentComboBox.SelectedItem).StudentId,
                    CourseId  = ((Course)courseComboBox.SelectedItem).CourseId,
                    Grade     = (gradeComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "",
                    DateAdded = dateAddedPicker.SelectedDate ?? DateTime.Today
                };

                resultRepository.AddResult(result);
                MessageBox.Show("Wynik został zapisany pomyślnie.", "Sukces",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd zapisu: " + ex.Message, "Błąd",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void clearResultButton_Click(object sender, RoutedEventArgs e) => ClearForm();
        private void cancelResultButton_Click(object sender, RoutedEventArgs e) => ClearForm();

        private void ClearForm()
        {
            studentComboBox.SelectedIndex = -1;
            courseComboBox.SelectedIndex  = -1;
            gradeComboBox.SelectedIndex   = -1;
            dateAddedPicker.SelectedDate  = DateTime.Today;
        }
    }
}
