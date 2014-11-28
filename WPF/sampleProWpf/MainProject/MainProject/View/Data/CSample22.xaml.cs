using MainProject.ViewModel.Data;
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

namespace MainProject.View.Data
{
    /// <summary>
    /// Interaction logic for CSample22.xaml
    /// </summary>
    public partial class CSample22 : UserControl
    {
        public CSample22()
        {
            InitializeComponent();
            this.DataContextChanged += CSample22_DataContextChanged;
        }

        void CSample22_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                ((CSample22Vm)e.NewValue).Instance = this;
            }
            catch (Exception) { }
        }
    }
}
