using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel
{
    public class CTestVm : ViewModelBase
    {

        public ICommand SendMessage
        {
            get { return new DelegateCommand<object>((x) => Content = Message); }
        }

        public ICommand SendNewLine
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {
                    Message += "\r\n";
                });
            }
        }

        private string mvMessage;
        public string Message
        {
            get { return mvMessage; }
            set
            {
                mvMessage = value;
                this.OnPropertyChanged(x => x.Message);
            }
        }

        private string mvContent;
        public string Content
        {
            get { return mvContent; }
            set { mvContent = value;
            this.OnPropertyChanged(x => x.Content);
            }
        }
        
    }
}
