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
    /// Interaction logic for CSample17.xaml
    /// </summary>
    public partial class CSample17 : UserControl
    {
        public CSample17()
        {
            InitializeComponent();
        }

        private void ctrColorPicker_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            txtColorChanged.Text = e.NewValue.ToString();
        }

        private void cmdFlip_Click(object sender, RoutedEventArgs e)
        {
            panel.IsFlipped = !panel.IsFlipped;
        }

    }
}
