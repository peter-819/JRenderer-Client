using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using JRenderer_Client.src;

namespace JRenderer_Client
{
    /// <summary>
    /// GLwindow.xaml 的交互逻辑
    /// </summary>
    public partial class GLwindow : Window
    {
        private GLHost glHost;
        private GLServer glServer;
        public GLwindow()
        {
            InitializeComponent(); 
            Application.Current.MainWindow = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //glHost = new GLHost(BorderHost);
            //BorderHost.Child = glHost;

            glServer = new GLServer(BorderServer);
            BorderServer.Child = glServer;

            //TreeViewLightNode lightNode = new TreeViewLightNode()
            //{
            //    Name = "Light1"
            //};

            //treeView.ItemsSource = new List<TreeViewLightNode>() { lightNode };

        }

        private bool PosInBorderServer(int x,int y)
        {
            return (x > 0 && y > 0 && x < BorderServer.Width && y < BorderServer.Height);
        }
        private bool PosInBorderServer(MouseEventArgs e)
        {
            int x = (int)e.GetPosition(BorderServer).X;
            int y = (int)e.GetPosition(BorderServer).Y;
            return PosInBorderServer(x,y);
        }
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            //Console.WriteLine($"{e.GetPosition(BorderServer).X},{e.GetPosition(BorderServer).Y}");

            int x = (int)e.GetPosition(BorderServer).X;
            int y = (int)e.GetPosition(BorderServer).Y;
            if (PosInBorderServer(e))
            {
                ClientSend.SendMouseMoveEvent(x, y);
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (PosInBorderServer(e))
            {
                ClientSend.SendMouseButtonEvent(0, 1);
            }
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (PosInBorderServer(e))
            {
                ClientSend.SendMouseButtonEvent(1, 1);
            }
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (PosInBorderServer(e))
            {
                ClientSend.SendMouseButtonEvent(0, 0);
            }
        }

        private void Window_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (PosInBorderServer(e))
            {
                ClientSend.SendMouseButtonEvent(1, 0);
            }
        }

        private void AddCubeButton_OnClick(object sender, RoutedEventArgs e)
        {
            FormManager.CreateMesh(0);
        }

        private void AddPlaneButton_OnClick(object sender, RoutedEventArgs e)
        {
            FormManager.CreateMesh(1);
        }

        private void ImportModelButton_OnClick(object sender, RoutedEventArgs e)
        {
            FormManager.CreateMesh(3);
        }

        private void AddLightButton_Click(object sender, RoutedEventArgs e)
        {
            FormManager.CreateLight();
        }
    }
}
