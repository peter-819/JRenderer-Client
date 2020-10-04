using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace JRenderer_Client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private IntPtr hwnd;
        public MainWindow()
        {
            InitializeComponent();
        }
        [DllImport("JRenderer-Client-Backend.dll")]
        private extern static IntPtr InitOpenGL(IntPtr hwnd);
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IntPtr ptr = InitOpenGL(hwnd);
            if (ptr != hwnd)
            {
                Debugger.Break();
            }
        }

        private void Frame_Initialized(object sender, EventArgs e)
        {
            hwnd = new WindowInteropHelper(this).Handle;
        }
    }
}
