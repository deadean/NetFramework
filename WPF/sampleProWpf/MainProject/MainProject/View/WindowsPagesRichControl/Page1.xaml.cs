using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainProject.View.WindowsPagesRichControl
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            this.Loaded += Page1_Loaded;
            this.Unloaded += Page1_Unloaded;
        }

        void Page1_Unloaded(object sender, RoutedEventArgs e)
        {
            (this.Resources["story1"] as Storyboard).Begin();
        }

        void Page1_Loaded(object sender, RoutedEventArgs e)
        {
            story.Begin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageFunction1 pageFunction = new PageFunction1();
            pageFunction.Return += pageFunction_Return;
            NavigationService.Navigate(pageFunction);
        }

        void pageFunction_Return(object sender, ReturnEventArgs<string> e)
        {
            MessageBox.Show("Call Back From PageFunction:"+e.Result);
        }
    }
}
