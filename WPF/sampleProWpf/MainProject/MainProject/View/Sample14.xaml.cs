using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace MainProject.View
{
    /// <summary>
    /// Interaction logic for Sample14.xaml
    /// </summary>
    public partial class Sample14 : UserControl
    {
        public Sample14()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // Get the selected type.
                var test = (lstTypes.SelectedItem as MainProject.ViewModel.CSample14Vm.CControlItem);
                Type type = test.CurrentType;
                ConstructorInfo info = type.GetConstructor(System.Type.EmptyTypes);
                Control control = (Control)info.Invoke(null);
                // Add it to the grid (but keep it hidden).
                control.Visibility = Visibility.Collapsed;
                grid.Children.Add(control);
                // Get the template.
                ControlTemplate template = control.Template;
                // Get the XAML for the template.
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                StringBuilder sb = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(sb, settings);
                XamlWriter.Save(template, writer);
                // Display the template.
                txtTemplate.Text = sb.ToString();
                grid.Children.Remove(control);
            }
            catch (Exception err)
            {
                txtTemplate.Text = "<< Error generating template: " + err.Message + ">>";
            }
        }
    }
}
