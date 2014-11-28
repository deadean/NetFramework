using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel
{
    public class CNotifItem:ViewModelBase
    {
        public string Name { get; set; }
        public string ID { get; set; }

        public ICommand CloseNotify
        {
            get { return new DelegateCommand<object>((x) => 
            {
                var vm = x as PopUpSampleVm;
                if (vm == null)
                    return;

                vm.NotifItems.Remove(this);
            }); }
        }
    }
}
