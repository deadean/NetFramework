using MainProject.View.WindowsPagesRichControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel.WindowsPagesRichControl
{
    public class CSample23Vm:ViewModelBase
    {
        
        #region Fields

        private DelegateCommand modStartWindow1Command;
        private DelegateCommand modStartNavigationWindowCommand;
        private DelegateCommand modNextPageCommand;
        private DelegateCommand modNextPage1Command;
        private DelegateCommand modPrevPageCommand;
        private DelegateCommand modNavigateCommand;
        private DelegateCommand modAddCommand;
        private DelegateCommand modStartCommand;
        private DelegateCommand modWriteIsolatedStorageFileCommand;

        private string modCurrentPageSource;
        private Page modCurrentPageSource1;
        private Page modCurrentPageSource2;
        private Stack<string> modCurrentPages = new Stack<string>();
        private IList<string> mvItems1 = new List<string>();
        private IList<string> mvItems2 = new List<string>();
        private string mvSelectedItem1;
        
        #endregion

        public CSample23Vm()
        {
            modStartWindow1Command = new DelegateCommand(OnStartWindow1Command);
            modStartNavigationWindowCommand = new DelegateCommand(OnStartNavigationWindowCommand);

            modNextPageCommand = new DelegateCommand(OnNextPageCommand);
            modNextPage1Command = new DelegateCommand(OnNextPage1Command);
            modPrevPageCommand = new DelegateCommand(OnPrevPageCommand);

            modNavigateCommand = new DelegateCommand(OnNaigateCommand);
            modAddCommand = new DelegateCommand(OnAddCommand);
            modStartCommand = new DelegateCommand(OnStartCommand);
            modWriteIsolatedStorageFileCommand = new DelegateCommand(OnWriteIsolatedStorageFileCommand);

            modCurrentPages.Push("Page1.xaml");
            modCurrentPages.Push("Page2.xaml");

            for (int i = 0; i < 5; i++)
            {
                Items1.Add(i.ToString());
            }

            CurrentPageSource = modCurrentPages.Pop();
            CurrentPageSource1 = new Page3();
            CurrentPageSource1.DataContext = this;
            CurrentPageSource2 = new Page1();
        }

        #region Properties

        public ICommand StartWindow1Command
        {
            get { return modStartWindow1Command; }
        }

				public ICommand Command1
				{
					get { return new DelegateCommand(() => { CWindow2 wnd = new CWindow2(); wnd.Owner = Application.Current.MainWindow; wnd.Show(); }); }
				}

        public ICommand StartNavigationWindowCommand
        {
            get { return modStartNavigationWindowCommand; }
        }

        public ICommand NextPageCommand
        {
            get { return modNextPageCommand; }
        }

        public ICommand AddCommand
        {
            get { return modAddCommand; }
        }

        public ICommand NextPage1Command
        {
            get { return modNextPage1Command; }
        }

        public ICommand PrevPageCommand
        {
            get { return modPrevPageCommand; }
        }

        public ICommand NavigateCommand
        {
            get { return modNavigateCommand; }
        }

        public ICommand StartCommand
        {
            get { return modStartCommand; }
        }

        public ICommand WriteIsolatedStorageFileCommand
        {
            get { return modWriteIsolatedStorageFileCommand; }
        }


        public string CurrentPageSource
        {
            get { return modCurrentPageSource; }
            set
            {
                modCurrentPageSource = value;
                this.OnPropertyChanged(x=>x.CurrentPageSource);
            }
        }

        public Page CurrentPageSource1
        {
            get { return modCurrentPageSource1; }
            set
            {
                modCurrentPageSource1 = value;
                this.OnPropertyChanged(x => x.CurrentPageSource1);
            }
        }

        public Page CurrentPageSource2
        {
            get { return modCurrentPageSource2; }
            set
            {
                modCurrentPageSource2 = value;
                this.OnPropertyChanged(x => x.CurrentPageSource2);
            }
        }

        public IList<string> Items1
        {
            get { return mvItems1; }
            set
            {
                mvItems1 = value;
                this.OnPropertyChanged(x=>x.Items1);
            }
        }

        public IList<string> Items2
        {
            get { return mvItems2; }
            set
            {
                mvItems2 = value;
                this.OnPropertyChanged(x => x.Items2);
            }
        }

        public string SelectedItem1
        {
            get { return mvSelectedItem1; }
            set
            {
                mvSelectedItem1 = value;
                this.OnPropertyChanged(x=>x.SelectedItem1);
            }
        }

        #endregion

        #region Private Service

        private void OnPrevPageCommand()
        {
            var cur = CurrentPageSource;
            CurrentPageSource = modCurrentPages.Pop();
            modCurrentPages.Push(cur);
        }

        private void OnNextPageCommand()
        {
            var cur = CurrentPageSource;
            CurrentPageSource = modCurrentPages.Pop();
            modCurrentPages.Push(cur);
        }

        private void OnNextPage1Command()
        {
            CurrentPageSource1 = new Page1();
        }

        private void OnAddCommand()
        {
            var selected = SelectedItem1;
            Items1.Clear();
            for (int i = 0; i < 5; i++)
            {
                Items1.Add(i.ToString());
            }

            Items2.Add(selected);
            Items1.Remove(selected);
            NavigationService nav = ((CSample23)this.ControlInstance).frame1.NavigationService;
            nav.AddBackEntry(GeyJournalEntry("Page" + DateTime.Now.ToString(),Items1.Select(x => x).ToList(), Items2.Select(x => x).ToList()));
        }

        public ListSelectionJournalEntry GeyJournalEntry(string p,IList<string> source, IList<string> target)
        {
            return new ListSelectionJournalEntry(source,target, p, Replay);
        }

        private void Replay(ListSelectionJournalEntry state)
        {
            Items1 = state.SourceItems;
            Items2 = state.TargetItems;
        }

        private void OnStartWindow1Command()
        {
            CWindow1 wnd = new CWindow1();
            wnd.Show();
        }

        private void OnStartNavigationWindowCommand()
        {
            NavigationWindow wnd = new NavigationWindow();
            wnd.Content = new Page1();
            wnd.Show();
        }

        private void OnNaigateCommand()
        {
            ((CSample23)ControlInstance).frame.Navigate(new Page1());
        }

        private void OnStartCommand()
        {
        }

        private void OnWriteIsolatedStorageFileCommand()
        {
            try
            {
                IsolatedStorageFile store = IsolatedStorageFile.GetStore(IsolatedStorageScope.User, null);
                using (IsolatedStorageFileStream fs = new IsolatedStorageFileStream("dean.txt", FileMode.Create, store))
                {
                    fs.WriteByte(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        
    }
}
