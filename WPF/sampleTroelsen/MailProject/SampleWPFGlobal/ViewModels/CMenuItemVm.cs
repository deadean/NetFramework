using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels
{
    public class CMenuItemVm:ViewModelBase
    {
        public CMenuItemVm()
        {
        }
        private string mvName = String.Empty;
        public string Name
        {
            get { return mvName; }
            set { mvName = value; this.OnPropertyChanged(x => x.Name); }
        }

        private ICommand mvCommand;
        public ICommand ActivateCommand
        {
            get { return mvCommand; }
            set { mvCommand = value; this.OnPropertyChanged(x => x.ActivateCommand); }
        }

        private ObservableCollection<CMenuItemVm> mvSubMenu = new ObservableCollection<CMenuItemVm>();
        public ObservableCollection<CMenuItemVm> SubMenu 
        {
            get { return mvSubMenu; }
            set
            {
                mvSubMenu = value;
                this.OnPropertyChanged(x=>x.SubMenu);
            }
        }
    }
}
