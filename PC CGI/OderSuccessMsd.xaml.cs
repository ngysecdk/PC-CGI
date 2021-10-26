using System.Windows;
namespace PC_CGI
{
    public partial class OderSuccessMsd : Window
    {
        public OderSuccessMsd(string ID)
        {
            InitializeComponent();
            TextID.Text += ID;
        }
        private void Button_Click(object sender, RoutedEventArgs e) => Close();
    }
}
