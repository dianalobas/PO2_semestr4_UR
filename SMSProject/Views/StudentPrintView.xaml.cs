using SMSProject.Data;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SMSProject.Views
{
    public partial class StudentPrintView : UserControl
    {
        private StudentRepository studentRepository = new StudentRepository();

        public StudentPrintView()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            try { printStudentsGrid.ItemsSource = studentRepository.GetAllStudents(); }
            catch (Exception ex) { MessageBox.Show("Błąd ładowania: " + ex.Message); }
        }

        private void previewButton_Click(object sender, RoutedEventArgs e) => LoadStudents();
        private void filterButton_Click(object sender, RoutedEventArgs e)  => LoadStudents();
        private void clearPrintButton_Click(object sender, RoutedEventArgs e)
        {
            printStudentsGrid.ItemsSource = null;
            printSearchBox.Clear();
        }
        private void exportButton_Click(object sender, RoutedEventArgs e)
            => MessageBox.Show("Funkcja eksportu do rozbudowy.", "Export");
        private void printButton_Click(object sender, RoutedEventArgs e)
            => MessageBox.Show("Funkcja drukowania do rozbudowy.", "Drukuj");
    }
}
