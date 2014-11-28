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
    /// Interaction logic for CSample21.xaml
    /// </summary>
    public partial class CSample21 : UserControl
    {
        public CSample21()
        {
            InitializeComponent();
            this.DataContextChanged += CSample21_DataContextChanged;
        }

        void CSample21_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                (e.NewValue as CSample21Vm).Instance = this;
            }
            catch (Exception) { }
        }


    }
}
