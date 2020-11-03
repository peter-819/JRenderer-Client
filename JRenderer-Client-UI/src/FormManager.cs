using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JRenderer_Client.src
{
    class FormManager
    {
        public static void Login()
        {
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                Application.Current.MainWindow.Hide();
                GLwindow gLwindow = new GLwindow();
                gLwindow.Show();
            }));
        }
    }
}
