using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels
{
    public class CTabItem:ViewModelBase
    {
        public string Header { get; set; }

        private ViewModelBase mvCurrentItem;
        public ViewModelBase CurrentItem
        {
            get { return mvCurrentItem; }
            set
            {
                mvCurrentItem = value;
                this.OnPropertyChanged(x => x.CurrentItem);
            }
        }
    }
}
