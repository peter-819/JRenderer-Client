using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Annotations;
/// <summary>
/// 向服务端发送信息
/// </summary>
public class ClientSend
{
    /// <summary>
    /// 发送TCP Packet信息
    /// </summary>
    /// <param name="_packet"></param>
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }
    /// <summary>
    /// 发送UDP Packet消息
    /// </summary>
    /// <param name="_packet"></param>
    private static void SendUDPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }
    #region Packets
    /// <summary>
    /// 收到Welcome信息，回复ID与username
    /// </summary>
    public static void WelcomeReceived()
    {
        using(Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write("peter_819");
            SendTCPData(_packet);
        }
    }
    public static void SendString(string str)
    {
        using(Packet _packet = new Packet((int)ClientPackets.sendString))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(str);
            SendTCPData(_packet);
        }
    }
    public static void SendData(byte[] array)
    {
        using (Packet _packet = new Packet((int)ClientPackets.sendDataPackets))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(array.Length);
            _packet.Write(array);
            SendUDPData(_packet);
        }
    }
    public static void SendLoginData(string username, string password)
    {
        using(Packet _packet = new Packet((int)ClientPackets.sendLoginData))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(username);
            _packet.Write(password);
            SendTCPData(_packet);
        }
    }
    #endregion
}
