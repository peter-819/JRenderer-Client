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

    public static void SendInitInfo(int width,int height)
    {
        using (Packet _packet = new Packet((int)ClientPackets.sendInitInfo))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(width);
            _packet.Write(height);
            SendTCPData(_packet);
        }
    }
    /// <summary>
    /// send button event
    /// </summary>
    /// <param name="button">0:left 1:right</param>
    /// <param name="action">0:pressed 1:released</param>
    public static void SendMouseButtonEvent(byte button,byte action)
    {
        using(Packet packet = new Packet((int)ClientPackets.sendMouseButtonEvent))
        {
            packet.Write(Client.instance.myId);
            packet.Write(button);
            packet.Write(action);
            SendUDPData(packet);
        }
    }

    public static void SendMouseMoveEvent(int X,int Y)
    {
        using(Packet packet = new Packet((int)ClientPackets.sendMouseMoveEvent))
        {
            packet.Write(Client.instance.myId);
            packet.Write(X);
            packet.Write(Y);
            SendUDPData(packet);
        }
    }
    
    public static void SendCreateSignal(int shape,double scale,double x,double y,double z)
    {
        using(Packet packet = new Packet((int)ClientPackets.sendCreateSignal))
        {
            packet.Write(Client.instance.myId);
            packet.Write(shape);

            packet.Write((float)scale);
            packet.Write((float)x);
            packet.Write((float)y);
            packet.Write((float)z);
            SendTCPData(packet);
        }
    }

    public static void SendLightData(double als,double dls,double slr,double slp,double x, double y,double z)
    {
        using (Packet packet = new Packet((int)ClientPackets.sendLightData))
        {
            packet.Write(Client.instance.myId);
            packet.Write((float)als);
            packet.Write((float)dls);
            packet.Write((float)slr);
            packet.Write((float)slp);
            packet.Write((float)x);
            packet.Write((float)y);
            packet.Write((float)z);
            SendTCPData(packet);
        }
    }

    #endregion
}
