using System.Net;
using System.Net.Sockets;
using System.Text;

using var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
 
var localIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8005);
udpSocket.Bind(localIP);
Console.WriteLine("UDP-сервер запущен...");

while (true)
{
    var data = new byte[65536];
    EndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);
    var result = await udpSocket.ReceiveFromAsync(data, SocketFlags.None, remoteIp);
    var message = Encoding.UTF8.GetString(data, 0, result.ReceivedBytes);
 
    Console.WriteLine($"Получено {result.ReceivedBytes} байт");
    Console.WriteLine($"Удаленный адрес: {result.RemoteEndPoint}");
    Console.WriteLine(message);

    if (message == "/STOP")
    {
        break;
    }
}
