using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows;
//https://fooobar.com/questions/63815/how-to-convert-a-structure-to-a-byte-array-in-c


namespace PC_CGI
{
    class DataDownload
    {
        Cryptor cryptor;
        Socket socket;
        static int port = 7755;              /// порт сервера
        static string address = "192.168.0.1"; /// адрес сервера
        public DataDownload()
        {
            //Curve25519()
            cryptor = new Cryptor();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // подключаемся к удаленному хосту
            retry:
            try { socket.Connect(IPAddress.Parse(address), port); }
            catch (System.Exception e) { 
                if (System.Windows.MessageBox.Show(e.Message + "\nПовторить попытку? (Не думаю. что это поможет)", 
                    "Ошибка при подключении к серверу",
                    System.Windows.MessageBoxButton.YesNo,
                    System.Windows.MessageBoxImage.Question,
                    System.Windows.MessageBoxResult.Yes,
                    System.Windows.MessageBoxOptions.DefaultDesktopOnly) == System.Windows.MessageBoxResult.No)
                    Application.Current.Shutdown(-1);
                else goto retry;
            }
            
        }

        ~DataDownload()
        {
            if (socket.Connected) socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }


}
