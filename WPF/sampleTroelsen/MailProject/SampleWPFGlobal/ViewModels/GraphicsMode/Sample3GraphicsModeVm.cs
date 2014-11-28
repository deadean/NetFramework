using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using ViewModelLib;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels.GraphicsMode
{
    public class Sample3GraphicsModeVm:ViewModelBase
    {
        public ICommand RotateCommand
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {
                    var param = x as FrameworkElement;
                    RotateTransform rotate = new RotateTransform(180);
                    param.LayoutTransform = rotate;
                });
            }
        }

        public ICommand SkewCommand
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {
                    var param = x as FrameworkElement;
                    SkewTransform rotate = new SkewTransform(40, -20);
                    param.LayoutTransform = rotate;
                });
            }
        }

        public ICommand FlipCommand
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {
                    var param = x as FrameworkElement;
                    ScaleTransform rotate = new ScaleTransform(-1, 1);
                    param.LayoutTransform = rotate;
                });
            }
        }
    }
}
