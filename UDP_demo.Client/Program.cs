using System.Net;
using System.Net.Sockets;
using System.Text;
 
using var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
 
Console.Write("Введите сообщение - ");
var message = Console.ReadLine();
var data = Encoding.UTF8.GetBytes(message);
EndPoint remotePoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8005);
var bytes = await udpSocket.SendToAsync(data, SocketFlags.None, remotePoint);
Console.WriteLine($"Отправлено {bytes} байт");