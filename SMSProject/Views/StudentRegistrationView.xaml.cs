using SMSProject.Data;
using SMSProject.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SMSProject.Views
{
    public partial class StudentRegistrationView : UserControl
    {
        private StudentRepository studentRepository = new StudentRepository();

        public StudentRegistrationView()
        {
            InitializeComponent();
        }

        private void saveStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateStudentForm()) return;

            try
            {
                Student student = new Student
                {
                    FirstName   = firstNameTextBox.Text.Trim(),
                    LastName    = lastNameTextBox.Text.Trim(),
                    AlbumNumber = albumNumberTextBox.Text.Trim(),
                    Email       = emailTextBox.Text.Trim(),
                    Gender      = (genderComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "",
                    GroupId     = int.TryParse(
                                      (groupComboBox.SelectedItem as ComboBoxItem)?.Tag?.ToString(), out int gid)
                                  ? gid : 1
                };

                studentRepository.AddStudent(student);
                MessageBox.Show("Student został zapisany pomyślnie.", "Sukces",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd zapisu: " + ex.Message, "Błąd",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void clearStudentButton_Click(object sender, RoutedEventArgs e) => ClearForm();

        private void cancelStudentButton_Click(object sender, RoutedEventArgs e) => ClearForm();

        private void ClearForm()
        {
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            albumNumberTextBox.Clear();
            emailTextBox.Clear();
            genderComboBox.SelectedIndex = -1;
            groupComboBox.SelectedIndex  = -1;
        }

        private bool ValidateStudentForm()
        {
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text))
            {
                MessageBox.Show("Uzupełnij imię."); return false;
            }
            if (string.IsNullOrWhiteSpace(lastNameTextBox.Text))
            {
                MessageBox.Show("Uzupełnij nazwisko."); return false;
            }
            if (string.IsNullOrWhiteSpace(albumNumberTextBox.Text))
            {
                MessageBox.Show("Uzupełnij numer albumu."); return false;
            }
            if (genderComboBox.SelectedItem == null)
            {
                MessageBox.Show("Wybierz płeć."); return false;
            }
            if (groupComboBox.SelectedItem == null)
            {
                MessageBox.Show("Wybierz grupę."); return false;
            }
            return true;
        }
    }
}
