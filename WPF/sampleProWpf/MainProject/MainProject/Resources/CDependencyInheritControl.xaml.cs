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

namespace MainProject.Resources
{
    /// <summary>
    /// Interaction logic for CDependencyInheritControl.xaml
    /// </summary>
    public partial class CDependencyInheritControl : UserControl
    {
        public static readonly DependencyProperty FirstTextProperty = CDependencyControl.FirstTextProperty.AddOwner(typeof(CDependencyInheritControl));

        public CDependencyInheritControl()
        {
            InitializeComponent();
        }

        public string FirstText
        {
            set { SetValue(FirstTextProperty, value); }
            get { return (string)GetValue(FirstTextProperty); }
        }
    }
}
