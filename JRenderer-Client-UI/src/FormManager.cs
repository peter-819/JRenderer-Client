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

                ClientSend.SendInitInfo((int)gLwindow.BorderServer.Width, (int)gLwindow.BorderServer.Height);
            }));
        }

        public static void CreateLight()
        {
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                RenderSetting lightWindow = new RenderSetting();
                lightWindow.Show();
                Application.Current.MainWindow = lightWindow;
            }));
        }

        public static void CreatedLight()
        {
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                Application.Current.MainWindow.Hide();
            }));
        }

        public static void CreateMesh(int shape)
        {
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                MeshSetting meshSetting = new MeshSetting();
                meshSetting.ShapeID = shape;
                meshSetting.Show();
                Application.Current.MainWindow = meshSetting;
            }));
        }
        public static void CreatedMesh()
        {
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                Application.Current.MainWindow.Hide();
            }));
        }
    }
}
