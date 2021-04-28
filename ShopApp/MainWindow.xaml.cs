using System.Windows;

namespace ShopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignOutBtnClick(object sender, RoutedEventArgs e)
        {
            AvtorizationWindow aw = new AvtorizationWindow();
            aw.Show();
            this.Close();
        }
    }
}