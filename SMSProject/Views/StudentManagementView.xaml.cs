using SMSProject.Data;
using SMSProject.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SMSProject.Views
{
    public partial class StudentManagementView : UserControl
    {
        private StudentRepository studentRepository = new StudentRepository();

        public StudentManagementView()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            try
            {
                studentsDataGrid.ItemsSource = studentRepository.GetAllStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania danych: " + ex.Message, "Błąd",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void refreshStudentButton_Click(object sender, RoutedEventArgs e) => LoadStudents();

        private void searchStudentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var all = studentRepository.GetAllStudents();
                string q = searchTextBox.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(q))
                    all = all.Where(s =>
                        s.FirstName.ToLower().Contains(q) ||
                        s.LastName.ToLower().Contains(q) ||
                        s.AlbumNumber.ToLower().Contains(q)).ToList();
                studentsDataGrid.ItemsSource = all;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd wyszukiwania: " + ex.Message);
            }
        }

        private void deleteStudentButton_Click(object sender, RoutedEventArgs e)
        {
            Student? selectedStudent = studentsDataGrid.SelectedItem as Student;
            if (selectedStudent == null)
            {
                MessageBox.Show("Wybierz studenta do usunięcia.", "Brak wyboru",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult result = MessageBox.Show(
                "Czy na pewno chcesz usunąć wybranego studenta?",
                "Potwierdzenie",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    studentRepository.DeleteStudent(selectedStudent.StudentId);
                    LoadStudents();
                    MessageBox.Show("Student został usunięty.", "Sukces",
                                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd usuwania: " + ex.Message, "Błąd",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void editStudentButton_Click(object sender, RoutedEventArgs e)
        {
            Student? s = studentsDataGrid.SelectedItem as Student;
            if (s == null)
            {
                MessageBox.Show("Wybierz studenta do edycji.", "Brak wyboru",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            MessageBox.Show($"Edycja studenta: {s.FullName}\n(funkcja do rozbudowy)", "Edycja");
        }

        private void detailsStudentButton_Click(object sender, RoutedEventArgs e)
        {
            Student? s = studentsDataGrid.SelectedItem as Student;
            if (s == null)
            {
                MessageBox.Show("Wybierz studenta.", "Brak wyboru",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            MessageBox.Show(
                $"ID: {s.StudentId}\nImię: {s.FirstName}\nNazwisko: {s.LastName}\n" +
                $"Nr albumu: {s.AlbumNumber}\nEmail: {s.Email}\nPłeć: {s.Gender}\nGrupa: {s.GroupId}",
                "Szczegóły studenta");
        }
    }
}
