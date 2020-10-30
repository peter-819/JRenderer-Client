using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JRenderer_Client
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            Thread thread = new Thread(() =>
            {
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

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = Username.Text;
            string password = Password.Password;

            byte[] data = new byte[50000];
            for(int i = 0; i < 50000; i++)
            {
                data[i] = 3;
            }
            ClientSend.SendData(data);
        }
    }
}
