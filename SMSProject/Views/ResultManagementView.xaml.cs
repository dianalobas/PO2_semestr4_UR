using SMSProject.Data;
using SMSProject.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SMSProject.Views
{
    public partial class ResultManagementView : UserControl
    {
        private ResultRepository resultRepository = new ResultRepository();

        public ResultManagementView()
        {
            InitializeComponent();
            LoadResults();
        }

        private void LoadResults()
        {
            try { resultsDataGrid.ItemsSource = resultRepository.GetAllResults(); }
            catch (Exception ex)
            { MessageBox.Show("Błąd ładowania wyników: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void refreshResultButton_Click(object sender, RoutedEventArgs e) => LoadResults();

        private void searchResultButton_Click(object sender, RoutedEventArgs e) => LoadResults();

        private void deleteResultButton_Click(object sender, RoutedEventArgs e)
        {
            Result? r = resultsDataGrid.SelectedItem as Result;
            if (r == null) { MessageBox.Show("Wybierz wynik do usunięcia.", "Brak wyboru", MessageBoxButton.OK, MessageBoxImage.Warning); return; }

            if (MessageBox.Show("Czy na pewno chcesz usunąć wybrany wynik?", "Potwierdzenie",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try { resultRepository.DeleteResult(r.ResultId); LoadResults(); }
                catch (Exception ex) { MessageBox.Show("Błąd usuwania: " + ex.Message); }
            }
        }

        private void editResultButton_Click(object sender, RoutedEventArgs e)
        {
            Result? r = resultsDataGrid.SelectedItem as Result;
            if (r == null) { MessageBox.Show("Wybierz wynik do edycji.", "Brak wyboru", MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            MessageBox.Show($"Edycja wyniku ID: {r.ResultId}\n(funkcja do rozbudowy)", "Edycja");
        }
    }
}
