using System.Net;
using System.Net.Sockets;
//https://fooobar.com/questions/63815/how-to-convert-a-structure-to-a-byte-array-in-c

namespace PC_CGI
{
    class DataDownload
    {
        Cryptor cryptor;
        Socket socket;
        static int port = 7755;              /// порт сервера
        static string address = "192.168.0.1"; /// адрес сервера
        DataDownload()
        {
            //Curve25519()
            cryptor = new Cryptor();
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // подключаемся к удаленному хосту
            socket.Connect(ipPoint);
        }

        ~DataDownload()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }


}
