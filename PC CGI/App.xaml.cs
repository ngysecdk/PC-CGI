using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows;

namespace PC_CGI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        static DataDownload dataDownloader;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var splash = new SplashScreen("Images/SplashScreen.png");
            splash.Show(false);
            dataDownloader = new DataDownload();
            splash.Close(TimeSpan.FromSeconds(2));
        }
    }
}
