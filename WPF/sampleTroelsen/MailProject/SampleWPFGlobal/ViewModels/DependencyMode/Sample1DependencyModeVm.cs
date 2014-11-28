using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels.DependencyMode
{
    public class Sample1DependencyModeVm:ViewModelBase
    {

        public static ICommand CommonCommand
        {
            get { return new DelegateCommand(() => { MessageBox.Show("Common Command"); }); }
        }
    }
}
