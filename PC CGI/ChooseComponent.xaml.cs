using System.Data;
using System.Windows;
namespace PC_CGI
{
    public partial class ChooseComponent : Window
    {
        public ChooseComponent() => InitializeComponent();
        public string GetId(DataTable table)
        {
            if (table == null) return "";
            TableDG.ItemsSource = table.DefaultView;
            ShowDialog();
            return (TableDG.SelectedItem == null) ? "" : (string)((DataRowView)TableDG.SelectedItem)["Код"];
        }
        private void Choose_Click(object sender, RoutedEventArgs e) => Close();
    }
}
