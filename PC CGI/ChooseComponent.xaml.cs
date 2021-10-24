using System.Data;
using System.Windows;
namespace PC_CGI
{
    public partial class ChooseComponent : Window
    {
        string ID = "";
        public ChooseComponent() => InitializeComponent();
        public string GetId(DataTable table)
        {
            if (table == null) return "";
            TableDG.ItemsSource = table.DefaultView;
            ShowDialog();
            return ID;
        }
        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            var Item = (DataRowView)TableDG.SelectedItem;
            if (Item != null) ID = (string)Item["Код"];
            Close();
        }
    }
}
