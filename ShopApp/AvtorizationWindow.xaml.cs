using System.Data.Common;
using System.Data.Odbc;
using System.Windows;
using ShopApp.Connection;

namespace ShopApp
{
    public partial class AvtorizationWindow : Window
    {
        public AvtorizationWindow()
        {
            InitializeComponent();
        }

        private void Avtorization_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            //DoSqlCommand();
            this.Close();
        }

        void DoSqlCommand()
        {
            var res = DBConnection.DoSqlCommand("SELECT * FROM users", 3);
            MessageBox.Show(res[1].ToString());
        }
    }
}