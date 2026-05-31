using System.Windows;

namespace SMSProject
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = userName.Text.Trim();
            string haslo = password.Password.Trim();

            // Walidacja pustych pól
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(haslo))
            {
                MessageBox.Show(
                    "Wprowadź login i hasło.",
                    "Brak danych",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );

                userName.Clear();
                password.Clear();
                userName.Focus();
                return;
            }

            // Sprawdzenie danych logowania
            if (login == "admin" && haslo == "admin123")
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Nieprawidłowy login lub hasło.",
                    "Błąd logowania",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );

                // Czyszczenie pól po błędzie
                password.Clear();
                userName.Clear();
                userName.Focus();
            }
        }
    }
}
