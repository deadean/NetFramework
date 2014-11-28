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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MotionBlur = false;
            AnimationDuration = TimeSpan.FromMilliseconds(1200);
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void ZoomWindow_Initialized(object sender, EventArgs e)
        {
            //Thread.Sleep(1000);
        }
    }
}
