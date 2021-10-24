using System;
using System.Threading;
using System.Windows;
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
    }
}
