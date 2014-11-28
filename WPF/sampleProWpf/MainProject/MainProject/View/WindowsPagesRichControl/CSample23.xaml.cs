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
using ViewModelLib.Types;

namespace MainProject.View.WindowsPagesRichControl
{
    /// <summary>
    /// Interaction logic for CSample23.xaml
    /// </summary>
    public partial class CSample23 : UserControl
    {
        public CSample23()
        {
            InitializeComponent();
            this.DataContextChanged += CSample23_DataContextChanged;
        }

        void CSample23_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
                return;

            ((IViewModelBase)e.NewValue).ControlInstance = this;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            browser.Navigate(new Uri("http://www.buildwindows.com/", UriKind.RelativeOrAbsolute));
        }
    }
}
