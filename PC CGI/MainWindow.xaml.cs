using System;
using System.Windows;
namespace PC_CGI
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
        private void Close_Click(object sender, RoutedEventArgs e) => Environment.Exit(0);
        private void NewGuitar_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new NewGuitar().ShowDialog();
            Show();
        }
    }
}
