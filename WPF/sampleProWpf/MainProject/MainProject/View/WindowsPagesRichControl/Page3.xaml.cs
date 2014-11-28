using MainProject.ViewModel.WindowsPagesRichControl;
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
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page//, IProvideCustomContentState
    {
        public Page3()
        {
            InitializeComponent();
        }

        //public CustomContentState GetContentState()
        //{
        //    //return ((CSample23Vm)this.DataContext).GeyJournalEntry("Page"+DateTime.Now.ToString());
        //}
    }
}
