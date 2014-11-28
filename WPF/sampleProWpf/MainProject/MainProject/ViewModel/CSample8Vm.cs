using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel
{
    public class CSample8Vm:ViewModelBase
    {
        public ICommand MouseEnterCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    MessageBox.Show("MouseEnter");

                });
            }
        }
    }
}
