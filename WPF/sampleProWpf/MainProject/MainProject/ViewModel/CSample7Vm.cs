using MainProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using ViewModelLib.Commands;
using ViewModelLib.Types;
using ViewModelLib.VisualTree;

namespace MainProject.ViewModel
{
    public class CSample7Vm : ViewModelBase
    {
        public ICommand ChangeResources
        {
            get
            {
                return new DelegateCommand<FrameworkElement>((x) =>
                    {
                        var brush = (SolidColorBrush)x.Resources["backgroundBrushDynamic"];
                        brush.Color = Colors.Red;
                    });
            }
        }
    }
}
 