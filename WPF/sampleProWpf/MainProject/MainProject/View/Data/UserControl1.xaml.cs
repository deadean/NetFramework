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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public string MyProperty
        {
            get { return (string)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value);  }
        }
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(string), typeof(UserControl1), new FrameworkPropertyMetadata(""));

        public IEnumerable<object> ItemsSourceDp
        {
            get { return (IEnumerable<object>)GetValue(ItemsSourceDpProperty); }
            set { SetValue(ItemsSourceDpProperty, value); }
        }
        public static readonly DependencyProperty ItemsSourceDpProperty =
            DependencyProperty.Register("ItemsSourceDp", typeof(IEnumerable<object>), typeof(UserControl1), new FrameworkPropertyMetadata(null));

        private void treeView_Expanded(object sender, RoutedEventArgs e)
        {

        }

    }
}
