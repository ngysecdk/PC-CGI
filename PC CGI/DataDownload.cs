using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows;
using System.Data;
using System.Collections.Generic;
using System.Text;
//https://fooobar.com/questions/63815/how-to-convert-a-structure-to-a-byte-array-in-c


namespace PC_CGI
{
    class DataDownload
    {
        List<DataTable> tables;
        Cryptor cryptor;
        Socket socket;
        static int port = 7755;                 /// порт сервера
        static string address = "192.168.0.1";  /// адрес сервера
        public DataDownload()
        { 
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
            cryptor = new Cryptor(socket);
            socket.Send(Encoding.ASCII.GetBytes("Start"));
            for (int i = 0; i < 10; i++) AddTable();

        }

        void AddTable()
        {
            DataTable dataTable = new DataTable();
            byte[] buffer = new byte[];
            socket.Receive(buffer);
            dataTable.TableName = Encoding.ASCII.GetString(buffer).Replace("Table=", "");
            while (true)
            {
                byte[] buff = new byte[];
                socket.Receive(buff);
                string getted = Encoding.ASCII.GetString(buffer);
                if (getted == "ENDTABLE") break;
                DataRow row = dataTable.NewRow();
                row.ItemArray = getted.Split('|');
            }
            tables.Add(dataTable);
        }

        ~DataDownload()
        {
            if (socket.Connected) socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }


}
