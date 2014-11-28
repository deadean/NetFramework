using MainProject.ViewModel.Documents_And_Printing;
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

namespace MainProject.View.Documents_And_Printing
{
    /// <summary>
    /// Interaction logic for CSample27View.xaml
    /// </summary>
    public partial class CSample27View : UserControl
    {
        public CSample27View()
        {
            InitializeComponent();
            this.DataContextChanged += CSample27View_DataContextChanged;
        }

        void CSample27View_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            (e.NewValue as CSample27Vm).ControlInstance = this;
        }
    }
}
