using LizenzaDevelopment.ADAICA.Data.GLOB.ctrGLOB.ViewModel.Commands;
using System;
using System.Windows.Input;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels
{
    public class Sample1Vm:ViewModelBase
    {
        private string mvApplicationWindowCount = String.Empty;
        public string ApplicationWindowCount 
        {
            get { return mvApplicationWindowCount; }
            set
            {
                
            }
        }

        public ICommand CloseCommand
        {
            get { return new RelayCommand((x) => { (x as MainWindow).Close(); }); }
        }
    }
}
