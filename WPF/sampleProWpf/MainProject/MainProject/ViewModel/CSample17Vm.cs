using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel
{
    public class CSample17Vm:ViewModelBase
    {
        private ICommand modColorChangedCommand;
        private ICommand modAttachedPropertyCommand;

        public CSample17Vm()
        {
            modColorChangedCommand = new DelegateCommand(OnColorChangedCommand);
            modAttachedPropertyCommand  = new DelegateCommand(OnAttachedPropertyCommand);
            modAttachedPropertyCommand = new DelegateCommand(OnAttachedPropertyCommandVm);
            CurrentColorInstance = Colors.Red;
        }

        public ICommand AttachedPropertyCommand
        {
            get { return modAttachedPropertyCommand; }
        }
        
        private void OnAttachedPropertyCommand()
        {
            AttachedValue = DateTime.Now.ToString();
        }
        private void OnAttachedPropertyCommandVm()
        {
            AttachedValue = DateTime.Now.ToString()+"Vm";
        }

        private string myVar;

        public string AttachedValue
        {
            get { return myVar; }
            set { myVar = value; this.OnPropertyChanged(x=>x.AttachedValue); }
        }

        private string myVarVm;

        public string AttachedValueVm
        {
            get { return myVarVm; }
            set { myVarVm = value; this.OnPropertyChanged(x => x.AttachedValueVm); }
        }


        private void OnColorChangedCommand()
        {
            CurrentColor = CurrentColorInstance.ToString();
        }

        public ICommand ColorChangedCommand
        {
            get { return modColorChangedCommand; }
        }

        private string mvCurrentColor;

        public string CurrentColor
        {
            get { return mvCurrentColor; }
            set { mvCurrentColor = value; this.OnPropertyChanged(x => x.CurrentColor); }
        }

        private Color mvCurrentColorInstance;
        public Color CurrentColorInstance
        {
            get { return mvCurrentColorInstance; }
            set { mvCurrentColorInstance = value; this.OnPropertyChanged(x => x.CurrentColorInstance); }
        }
        
    }
}
