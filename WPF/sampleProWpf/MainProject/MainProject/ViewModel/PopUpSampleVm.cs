using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Xml;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel
{
    public class PopUpSampleVm : ViewModelBase
    {
        private DispatcherTimer timer = new DispatcherTimer();
        public PopUpSampleVm()
        {
            this.NotifItems = new ObservableCollection<CNotifItem>();
            this.NotifItems.Add(new CNotifItem() { Name = "Item1", ID = "1" });

            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (IsOpenPopUp)
            {
                AddItem.Execute(null);
                return;
            }
                
            RunPopUp.Execute(null);
        }

        public ICommand RunPopUp
        {
            get { return new DelegateCommand(() => { IsOpenPopUp = true; }); }
        }

				public ICommand Command1
				{
					get { return new DelegateCommand(() => { IsOpen1 = true; }); }
				}

        public ICommand AddItem
        {
            get { return new DelegateCommand(() => { this.NotifItems.Add(new CNotifItem() { ID = "456", Name=DateTime.Now.ToString()}); }); }
        }

        public ICommand StartTimer
        {
            get { return new DelegateCommand(() => 
            {
                timer.Start();  
            }); }
        }

        private bool mvIsOpenPopUp = false;
        public bool IsOpenPopUp
        {
            get { return mvIsOpenPopUp; }
            set
            {
                mvIsOpenPopUp = value;
                this.OnPropertyChanged(x => x.IsOpenPopUp);
            }
        }

				private bool mvIsOpen1 = false;
				public bool IsOpen1
				{
					get { return mvIsOpen1; }
					set
					{
						mvIsOpen1 = value;
						this.OnPropertyChanged(x => x.IsOpen1);
					}
				}

        private ObservableCollection<CNotifItem> myNotifItems;

        public ObservableCollection<CNotifItem> NotifItems
        {
            get { return myNotifItems; }
            set { myNotifItems = value; }
        }
    }
}
