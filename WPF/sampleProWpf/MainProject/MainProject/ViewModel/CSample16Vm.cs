using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel
{
    public class CSample16Vm:ViewModelBase
    {
        private ICommand mvAddNewTab;
        public CSample16Vm()
        {
            Tabs = new ObservableCollection<ViewModelBase>() 
            { 
                new TabItemVm(){Header = "Tab1"},
                new TabItemVm(){Header = "Tab2"},
                new CSample14Vm()
            };
            mvAddNewTab = new DelegateCommand(AddNewTabMethod);

        }

        private void AddNewTabMethod()
        {
            Tabs.Add(new TabItemVm() { Header = String.Format("New Tab {0}", DateTime.Now.ToString()) });
        }

        public ObservableCollection<ViewModelBase> Tabs { get; set; }

        public ICommand AddNewTab
        {
            get { return mvAddNewTab; }
        }

    }

    public class TabItemVm : ViewModelBase
    {
        private string mvHeader;
        public string Header
        {
            get { return mvHeader; }
            set { mvHeader = value; this.OnPropertyChanged(x => x.Header); }
        }

    }
}
