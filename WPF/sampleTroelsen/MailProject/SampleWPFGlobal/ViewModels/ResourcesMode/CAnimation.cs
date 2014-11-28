using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels.ResourcesMode
{
    public class CAnimation:ViewModelBase
    {

        private string mvName;
        public string Name
        {
            get { return mvName; }
            set
            {
                mvName = value;
                this.OnPropertyChanged(x=>x.Name);
            }
        }

        public Func<ButtonBase, bool> Action { get; set; }
    }
}
