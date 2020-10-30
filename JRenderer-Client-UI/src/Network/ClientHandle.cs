using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

/// <summary>
/// 用来处理从服务端收到数据的函数
/// </summary>
public class ClientHandle
{
    /// <summary>
    /// 连接到服务端后收到Welcome消息
    /// </summary>
    /// <param name="_packet">Packet包含：消息字串，ID</param>
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();
        Console.WriteLine($"Message from server: {_msg}");
        Client.instance.myId = _myId;
        ClientSend.WelcomeReceived();
        Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }
}
