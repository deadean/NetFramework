using MainProject.Resources;
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
    public class CSample6Vm:ViewModelBase
    {
        private ICommand modStartRibbonWindowCommand;

        public CSample6Vm()
        {
            mvListStates = new ObservableCollection<enState>();
            mvListStates.Add(enState.Red);
            mvListStates.Add(enState.Green);
            modStartRibbonWindowCommand = new DelegateCommand(OnStartWindow);
        }

        private void OnStartWindow()
        {
            CRibbonWindow wnd = new CRibbonWindow();
            wnd.Show();
        }

        public ICommand StartRibbonWindowCommand { get { return modStartRibbonWindowCommand; } }

        public enum enState
        {
            Red,
            Green
        }

        private ObservableCollection<enState> mvListStates;

        public ObservableCollection<enState> ListStates
        {
            get { return mvListStates; }
            set 
            { 
                mvListStates = value;
                this.OnPropertyChanged(x=>x.ListStates);
            }
        }

        private enState mvCurrentState;

        public enState CurrentState
        {
            get { return mvCurrentState; }
            set { 
                mvCurrentState = value;
                this.OnPropertyChanged(x => x.CurrentState);
            }
        }
        
        
        
    }
}
