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
using ViewModelLib.VisualTree;

namespace MainProject.Resources
{
    /// <summary>
    /// Interaction logic for CDependencyControl.xaml
    /// </summary>
    public partial class CDependencyControl : UserControl
    {

        #region FirstTextProperty

        public static readonly DependencyProperty FirstTextProperty = DependencyProperty.RegisterAttached(
            "FirstText"
            , typeof(string)
            , typeof(DependencyProperty)
            , new FrameworkPropertyMetadata(default(string), (x, y) =>
            {
                var element = VisualTreeHelperExtensions.FindControl<Label>(x as FrameworkElement, "lbFirstText");

                if (element == null)
                    return;
                element.Content = y.NewValue;
            }) { CoerceValueCallback = (x, y) => { return y;} }
            , new ValidateValueCallback((x) => { return true; }));

        public string FirstText
        {
            set { SetValue(FirstTextProperty, value); }
            get { return (string)GetValue(FirstTextProperty); }
        }

        #endregion

        public CDependencyControl()
        {
            InitializeComponent();
        }
    }
}
