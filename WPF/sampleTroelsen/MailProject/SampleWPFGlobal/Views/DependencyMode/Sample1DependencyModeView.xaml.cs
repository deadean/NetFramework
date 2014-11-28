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

namespace SampleWPFGlobal.Views.DependencyMode
{
    public static class App1Commands
    {
        private static RoutedUICommand exitCommand = new RoutedUICommand("Exit1", "Exit1", typeof(App1Commands));

        public static RoutedCommand Exit1Command
        {
            get { return exitCommand; }
        }

        static App1Commands()
        {
            CommandBinding exitBinding = new CommandBinding(exitCommand);
            CommandManager.RegisterClassCommandBinding(typeof(App1Commands), exitBinding);
        }
    }

    /// <summary>
    /// Interaction logic for Sample1DependencyModeView.xaml
    /// </summary>
    public partial class Sample1DependencyModeView : UserControl
    {
        string mouseActivity = string.Empty;
        public Sample1DependencyModeView()
        {
            InitializeComponent();
        }

        private void outerEllipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.lbName.Content = e.RoutedEvent.RoutingStrategy;
            e.Handled = true;
        }

        private void outerEllipse_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.lbName.Content = e.RoutedEvent.RoutingStrategy;
        }
    }
}
