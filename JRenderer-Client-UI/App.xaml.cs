using JRenderer_Client.src;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace JRenderer_Client
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                FrameQueue.Create();
                Backend.InitBackend();
                Client.Create();
                Client.instance.ConnectToServer();
                while (true)
                {
                    ThreadManager.UpdateMain();
                    Thread.Sleep(10);
                }
            });
            thread.Start();
        }
    }
}
