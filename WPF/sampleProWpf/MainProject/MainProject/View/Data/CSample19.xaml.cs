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
    /// Interaction logic for CSample19.xaml
    /// </summary>
    public partial class CSample19 : UserControl
    {
        public CSample19()
        {
            InitializeComponent();
        }

        private void Grid_Error(object sender, ValidationErrorEventArgs e)
        {
            // Check that the error is being added (not cleared).
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }
    }
}
