using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace PC_CGI
{
    internal class DataDownload
    {
        public List<DataTable> tables = new List<DataTable>();
        Cryptor cryptor;
        Socket socket;
        static int port = 5555;                 /// порт сервера
        static string address = "192.168.0.2";  /// адрес сервера
        public DataDownload()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        retry:
            try { socket.Connect(IPAddress.Parse(address), port); }
            catch (Exception e)
            {
                if (MessageBox.Show(e.Message + "\nПовторить попытку?",
                    "Ошибка при подключении к серверу", MessageBoxButton.YesNo, MessageBoxImage.Question,
                    MessageBoxResult.Yes) == MessageBoxResult.No) Environment.Exit(-1);
                else goto retry;
            }
            cryptor = new Cryptor(socket);
            Send("Start");
            for (int i = 0; i < 10; i++) AddTable();
        }
        void AddTable()
        {
            DataTable dataTable = new DataTable();
            var Tableheader = Receive().Split('|');
            dataTable.TableName = Tableheader[0];
            for (int i = 1; i < Tableheader.Length; i++) dataTable.Columns.Add(Tableheader[i], typeof(string));
            while (true)
            {
                string getted = Receive();
                if (getted == "ENDTABLE\0") break;
                DataRow row = dataTable.NewRow();
                row.ItemArray = getted.Split('|');
                dataTable.Rows.Add(row);
                GC.Collect();
            }
            tables.Add(dataTable);
        }
        public int GetCost(string Table, string value)
        {
            if (value == "") return 0;
            Send(Table + "|" + value);
            int Cost;
            int.TryParse(Receive(), out Cost);
            return Cost;
        }
        public string FindRow(string TableName, string ID)
        {
            if (ID == "") return "";
            var table = tables.Find(i => i.TableName == TableName);
            DataRow row = table.AsEnumerable().SingleOrDefault(i => i.Field<string>("Код") == ID);
            string res = TableName + " : ";
            for (int i = 1; i < row.ItemArray.Length; i++) res += (string)row.ItemArray[i] + " ";
            return res + " = ";
        }
        byte[] size = new byte[4];
        public int Send(string text)
        {
            byte[] buff = Encoding.UTF8.GetBytes(text);
            byte[] SizeText = BitConverter.GetBytes((uint)buff.Length);
            socket.Send(SizeText);
            return socket.Send(buff);
        }
        public string Receive()
        {
            socket.Receive(size);
            byte[] buff = new byte[BitConverter.ToUInt32(size, 0)];
            socket.Receive(buff);
            return Encoding.UTF8.GetString(buff);
        }
        ~DataDownload()
        {
            if (socket.Connected) socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
