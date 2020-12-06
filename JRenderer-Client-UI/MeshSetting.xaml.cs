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
using JRenderer_Client.src;

namespace JRenderer_Client
{
    /// <summary>
    /// RenderSetting.xaml 的交互逻辑
    /// </summary>
    public partial class MeshSetting : Window
    {
        public int ShapeID { get; set; }
        public MeshSetting()
        {
            InitializeComponent(); 
            Application.Current.MainWindow = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            double scale = Scale.Value;
            double x = PositionX.Value;
            double y = PositionY.Value;
            double z = PositionZ.Value;

            ClientSend.SendCreateSignal(ShapeID,scale,x,y,z);
            FormManager.CreatedMesh();
        }
    }
}
