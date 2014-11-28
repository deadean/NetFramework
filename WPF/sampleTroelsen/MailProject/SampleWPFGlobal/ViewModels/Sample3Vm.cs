using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels
{
    public class Sample3Vm:ViewModelBase
    {

        public ICommand StartSaveFileDialogCommand
        {
            get
            {
                return new DelegateCommand(
                    () =>
                    {
                        var dialog = new SaveFileDialog();
                        dialog.ShowDialog();
                    }
                    );
            }
        }
    }
}
