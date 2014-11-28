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

namespace MainProject.View.WindowsPagesRichControl
{
    /// <summary>
    /// Interaction logic for PageFunction1.xaml
    /// </summary>
    public partial class PageFunction1 : PageFunction<String>
    {
        public PageFunction1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OnReturn(new ReturnEventArgs<string>() { Result = "ddddddddddddddddddddddd"});
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
