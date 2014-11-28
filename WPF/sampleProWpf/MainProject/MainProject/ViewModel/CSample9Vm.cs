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
    public class CSample9Vm:ViewModelBase
    {
        public CSample9Vm()
        {
            ViewBoxModes = new ObservableCollection<string>();
            ViewBoxModes.Add("None");
            ViewBoxModes.Add("Fill");
            ViewBoxModes.Add("Uniform");
            ViewBoxModes.Add("UniformToFill");
            ViewBoxMode = ViewBoxModes.First();
            StatePopUp = true;
        }

        private bool mvStatePopUp;

        public bool StatePopUp
        {
            get { return mvStatePopUp; }
            set { mvStatePopUp = value; this.OnPropertyChanged(x => x.StatePopUp); }
        }

        public ICommand ChangepopUpStateCommand
        {
            get
            {
                return new DelegateCommand(() =>
                    {
                        StatePopUp = !StatePopUp;
                    });
            }
        }
        

        public ObservableCollection<string> ViewBoxModes
        {
            get;
            set;
        }

        private string mvViewBoxMode;
        public string ViewBoxMode
        {
            get { return mvViewBoxMode; }
            set
            {
                mvViewBoxMode = value;
                this.OnPropertyChanged(x=>x.ViewBoxMode);
            }
        }
    }
}
