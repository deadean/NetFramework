using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels
{
    public class Sample5Vm:ViewModelBase
    {
        public ObservableCollection<CTabItem> TabItems { get; set; }

        public Sample5Vm()
        {
            TabItems = new ObservableCollection<CTabItem>();
            TabItems.Add(new CTabItem() { Header = "Ink API", CurrentItem = new Sample5Tab1Vm() });
            TabItems.Add(new CTabItem() { Header = "Documents", CurrentItem = new Sample5Tab2Vm() });
            TabItems.Add(new CTabItem() { Header = "Data Binding", CurrentItem = new Sample5Tab3Vm() });
            TabItems.Add(new CTabItem() { Header = "DataGrid", CurrentItem = new Sample5Tab4Vm() });
        }

    }
}
