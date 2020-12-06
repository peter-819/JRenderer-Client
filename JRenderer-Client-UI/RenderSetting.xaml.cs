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
    public partial class RenderSetting : Window
    {
        public RenderSetting()
        {
            InitializeComponent(); 
            Application.Current.MainWindow = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            double als = AmbientLightScalar.Value;
            double dls = DiffuseLightScalar.Value;
            double slr = SpecularLightRadius.Value;
            double slp = SpecularLightPow.Value;
            double x = PositionX.Value;
            double y = PositionY.Value;
            double z = PositionZ.Value;

            ClientSend.SendLightData(als, dls, slr, slp, x, y, z);
            FormManager.CreatedLight();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
