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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainProject.View
{
    /// <summary>
    /// Interaction logic for Sample9.xaml
    /// </summary>
    public partial class Sample9 : UserControl
    {
        public Sample9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            pop.PlacementTarget = (Button)sender;
            pop.IsOpen = true;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            pop.IsOpen = false;
        }
    }
}
