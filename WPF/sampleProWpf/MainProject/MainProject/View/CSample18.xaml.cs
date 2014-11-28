using MainProject.ViewModel;
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
using ViewModelLib.Commands;

namespace MainProject.View
{
    /// <summary>
    /// Interaction logic for CSample18.xaml
    /// </summary>
    public partial class CSample18 : UserControl
    {
        public CSample18()
        {
            InitializeComponent();
            DataContextChanged += CSample18_DataContextChanged;
        }

        void CSample18_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            e.NewValue.WithType<CSample18Vm>(x => x.Instance = this);
        }
    }
}
