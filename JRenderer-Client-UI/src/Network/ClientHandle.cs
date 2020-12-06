using JRenderer_Client;
using JRenderer_Client.src;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows;

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

    public static void PpmReceived(Packet _packet)
    {
        int length = _packet.ReadInt();
        byte[] data = _packet.ReadBytes(length);
        //PpmImage image = PpmImage.Deserialize(data);
        //Backend.RTInitilize();
        PpmImage image = new PpmImage();
        image.width = 960;
        image.height = 540;
        image.rgb = new byte[image.width * image.height * 3];
        Backend.RTInitilize();
        IntPtr ptr = Backend.RTrender();
        IntPtr iter = ptr;
        for(int i = 0; i < image.width * image.height; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                float color = (float)Marshal.PtrToStructure(iter, typeof(float));
                image.rgb[i * 3 + j] = (byte)color;
                iter = (IntPtr)(iter.ToInt64() + Marshal.SizeOf(typeof(float)));
            }
        }
        //Backend.TestImageSending(image);
    }

    public static void LoginResultReceived(Packet packet)
    {
        bool res = packet.ReadBool();
        if(res == true)
        {
            Console.WriteLine("Login success");
            FormManager.Login();
        }
        else
        {
            Console.WriteLine("Login failed");
        }
    }

    public static void JPEGBufferReceived(Packet packet)
    {
        int length = packet.ReadInt();
        byte[] data = packet.ReadBytes(length);
        PpmImage image = new PpmImage();
        
        IntPtr outBuffer = IntPtr.Zero;
        int outSize = 0;
        int outWidth = 0;
        int outHeight = 0;
        int outComponents = 0;

        IntPtr unmanagedPointer = Marshal.AllocHGlobal(data.Length);
        Marshal.Copy(data, 0, unmanagedPointer, data.Length);
        Backend.DecompressJPEG(unmanagedPointer, data.Length, 
            ref outBuffer, ref outSize, ref outWidth, ref outHeight, ref outComponents);
        Marshal.FreeHGlobal(unmanagedPointer);

        image.rgb = new byte[outSize];
        Marshal.Copy(outBuffer, image.rgb, 0, outSize);
        image.width = outWidth;
        image.height = outHeight;
        
        FrameQueue.queue.Enqueue(image);
    }
}
