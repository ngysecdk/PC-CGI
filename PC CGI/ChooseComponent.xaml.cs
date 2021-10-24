using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PC_CGI
{
    /// <summary>
    /// Логика взаимодействия для ChooseComponent.xaml
    /// </summary>
    public partial class ChooseComponent : Window
    {
        string ID = "1";
        public ChooseComponent() => InitializeComponent();
        string GetId(DataTable table)
        {
            TableDG.ItemsSource = table.DefaultView;
            ShowDialog();
            return ID;
        }
        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            var Item = TableDG.SelectedItem;
            Close();
        }
    }
}
