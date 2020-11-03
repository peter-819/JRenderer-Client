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
        public GLwindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            glHost = new GLHost(BorderHost1);
            BorderHost1.Child = glHost;
        }
    }
}
