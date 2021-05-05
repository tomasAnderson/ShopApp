using System.Data.Common;
using System.Data.Odbc;
using System.Linq;
using System.Windows;
using ShopApp.Connection;
using ShopApp.MyModel;

namespace ShopApp
{
    public partial class AvtorizationWindow : Window
    {
        public User CurrUser { get; set; }

        public AvtorizationWindow()
        {
            InitializeComponent();
        }

        private void Avtorization_OnClick(object sender, RoutedEventArgs e)
        {
            LogIn();
        }

        private void LogIn()
        {
            if (AvtorizationCheck())
            {
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();

                MessageBox.Show($"Здраствуй, {CurrUser.Name}", "Авторизован", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Неправильный логин или пароль", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool AvtorizationCheck()
        {
            var users = AllInfo.GetUsers();

            CurrUser = users.FirstOrDefault(x => x.Name.Trim() == login.Text.Trim());

            return (HashVerifycation.VerifySHA512Hash(password.Password.Trim(), CurrUser?.Password.Trim()));
        }
    }
}