using System;
using System.Collections.Generic;
using System.Text;
using JImGui.Common;
using JImGui.GUI;
using JImGui.GUI.Elements;

namespace JImGuiTest
{
    class MainForm : Form
    {
        protected override void OnGUI()
        {
            Rect rect = new Rect(new Point(10, 10), 30, 10);
            Elements.Label("Label1",rect,"hello world");
        }
    }
}
