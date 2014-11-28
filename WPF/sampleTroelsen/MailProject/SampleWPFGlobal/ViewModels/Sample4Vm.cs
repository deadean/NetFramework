using LizenzaDevelopment.ADAICA.Data.GLOB.ctrGLOB.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using ViewModelLib.Behaviours;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels
{
    public class Sample4Vm:ViewModelBase
    {
        public Sample4Vm()
        {
            this.MenuFiles = new ObservableCollection<CMenuItemVm>();
            this.MenuFiles.Add(new CMenuItemVm() { Name = "_Open", ActivateCommand = ApplicationCommands.Open });
            this.MenuFiles.Add(new CMenuItemVm() { Name = "_Save", ActivateCommand = ApplicationCommands.Save });
            this.MenuFiles.Add(new CMenuItemVm() { Name = "_Tools", ActivateCommand = new DelegateCommand(()=>{})});
            this.MenuFiles.Add(new CMenuItemVm() { Name = "_Exit", ActivateCommand = new RelayCommand((x) => { (x as MainWindow).Close(); }) });
            this.StatusText = "Ready";
        }
        public ObservableCollection<CMenuItemVm> MenuFiles { get; set; }

        public ICommand MouseLeaveCommand
        {
            get { return new RelayCommand((x) => 
            {
                StatusText = "Ready";
            }); }
        }

        public ICommand MouseEnterCommand
        {
            get
            {
                return new RelayCommand((x) =>
                {
                    StatusText = ((x as RoutedEventArgs).OriginalSource as ICommandSource).CommandParameter.ToString();
                });
            }
        }

        public ICommand MouseEnterTestCommand
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {
                    StatusText = x.ToString();
                });
            }
        }

        public ICommand MouseLeaveTestCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    StatusText = "Ready";
                });
            }
        }

        public ICommand CheckCommand
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                    {
                        var txtBox = x as TextBox;
                        var errors = txtBox.GetSpellingError(txtBox.CaretIndex);
                        var errorsString = String.Empty;
                        if (errors == null)
                            return;

                        errors.Suggestions.ToList().ForEach(y => errorsString += y + "\n");
                        Errors = errorsString;
                    });
            }
        }

        private string mvErrors = String.Empty;
        public string Errors 
        {
            get { return mvErrors; }
            set { mvErrors = value; this.OnPropertyChanged(x=>x.Errors); }
        }

        private string mvStatusText = String.Empty;
        public string StatusText 
        {
            get { return mvStatusText; }
            set
            {
                mvStatusText = value;
                this.OnPropertyChanged(x=>x.StatusText);
            }
        }
    }
}
