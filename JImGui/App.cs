using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using JImGui.GUI;

namespace JImGui
{
    public class App
    {
        List<Form> Forms;
        bool bRunning;
        Thread AppThread;
        public App()
        {
            Forms = new List<Form>();
        }
        ~App()
        {
            if (bRunning)
            {
                Shutdown();
            }
        }
        public void Init()
        {

        }
        public void AddForm(Form form)
        {
            Forms.Add(form);
        }
        public void Run()
        {
            bRunning = true;
            AppThread = new Thread(() => {
                while (bRunning)
                {
                    foreach (var f in Forms)
                    {
                        f.OnGUI();
                    }
                }
            });
        }
        public void Shutdown()
        {
            bRunning = false;
            AppThread.Join();
        }
    }
}
