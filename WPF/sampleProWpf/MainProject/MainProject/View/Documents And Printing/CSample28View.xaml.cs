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
    /// Interaction logic for CSample28View.xaml
    /// </summary>
    public partial class CSample28View : UserControl
    {
        public CSample28View()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true)
            {
                pd.PrintVisual(ctr1, "A Simple Drawing");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true)
            {
                pd.PrintDocument(((IDocumentPaginatorSource)ctr2.Document).DocumentPaginator, "A Flow Document");
            }
        }
    }
}
