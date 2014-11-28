using System.Windows;

namespace WpfApplicationForSampleLINQToXML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            tbInventory.Text = LINQToXMLObjectModel.GetXmlInventory().ToString();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            LINQToXMLObjectModel.InsertNewElement(tbMake.Text,tbColor.Text,tbPetName.Text);
            tbInventory.Text = LINQToXMLObjectModel.GetXmlInventory().ToString();
        }

        private void ButtonBase1_OnClick(object sender, RoutedEventArgs e)
        {
            LINQToXMLObjectModel.LookUpColorsForMake(tbMakeLookUp.Text);
        }
    }
}
