using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace PC_CGI
{
    public partial class NewGuitar : Window
    {
        Order order = new Order();
        DataDownload dataDownload;
        public NewGuitar()
        {
            var splash = new SplashScreen("Images/SplashScreen.png");
            splash.Show(false);
            dataDownload = new DataDownload();
            splash.Close(TimeSpan.FromSeconds(2));
            Thread.Sleep(2000);
            InitializeComponent();
        }
        private void Table_Click(object sender, EventArgs e)
        {
            TextButton cur = (TextButton)sender;
            order.Set(cur.TableName, new ChooseComponent().GetId(dataDownload.tables.Find(i => i.TableName == cur.TableName)));
            cur.Opacity = 0.5;
        }
        private void Close_Click(object sender, RoutedEventArgs e) => Close();
        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            new Calc(order, dataDownload).ShowDialog();
            Close();
        }

        private void TypeBuild_Click(object sender, RoutedEventArgs e)
        {
            order.Set("Вид_сборки", new ChooseComponent().GetId(dataDownload.tables.Find(i => i.TableName == "Вид_сборки")));
            ((Button)sender).Opacity = 0.5;
        }

        private void Coloring_Click(object sender, RoutedEventArgs e)
        {
            order.Set("Покраска", new ChooseComponent().GetId(dataDownload.tables.Find(i => i.TableName == "Покраска")));
            ((Button)sender).Opacity = 0.5;
        }
    }
}
