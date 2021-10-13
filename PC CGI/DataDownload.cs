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
        static int port = 7755;                 /// порт сервера
        static string address = "192.168.0.1";  /// адрес сервера
        public DataDownload()
        {
            cryptor = new Cryptor();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            retry:
            try { socket.Connect(IPAddress.Parse(address), port); }
            catch (System.Exception e) { 
                if (MessageBox.Show(e.Message + 
                    "\nПовторить попытку? (Не думаю. что это поможет)", 
                    "Ошибка при подключении к серверу",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question,
                    MessageBoxResult.Yes,
                    MessageBoxOptions.DefaultDesktopOnly) == MessageBoxResult.No)
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
