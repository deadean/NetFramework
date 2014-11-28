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
    /// Interaction logic for Sample8.xaml
    /// </summary>
    public partial class Sample8 : UserControl
    {
        public Sample8()
        {
            InitializeComponent();
        }

        private void element_MouseEnter(object sender, MouseEventArgs e)
        {
            MessageBox.Show("MouseEnter");
        }

    }
}
