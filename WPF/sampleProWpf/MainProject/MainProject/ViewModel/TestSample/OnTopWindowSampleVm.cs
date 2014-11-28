using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel.TestSample
{
    public class OnTopWindowSampleVm:ViewModelBase
    {
        #region Fields

        private ICommand modOpenWindow;
        
        #endregion

        #region Ctor

        public OnTopWindowSampleVm()
        {
            modOpenWindow = new DelegateCommand(OnOpenWindow);
        }

        

        
        #endregion

        #region Properties
        
        #endregion

        #region Commands

        public ICommand OpenWindowCommand { get { return modOpenWindow; } }

        #endregion

        #region Private Services

        private void OnOpenWindow()
        {
            
        }

        #endregion
    }
}
