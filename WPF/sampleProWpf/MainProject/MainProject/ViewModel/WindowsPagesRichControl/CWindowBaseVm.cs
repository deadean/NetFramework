using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel.WindowsPagesRichControl
{
    public class CWindowBaseVm:ViewModelBase
    {
        private DelegateCommand modWindowDragMoveCommand;

        public CWindowBaseVm()
        {
            modWindowDragMoveCommand = new DelegateCommand(OnDragMoveCommand);
        }

        public ICommand WindowDragMoveCommand
        {
            get { return modWindowDragMoveCommand; }
        }

        private void OnDragMoveCommand()
        {
            ((CWindowBase)this.ControlInstance).DragMove();
        }
    }
}
