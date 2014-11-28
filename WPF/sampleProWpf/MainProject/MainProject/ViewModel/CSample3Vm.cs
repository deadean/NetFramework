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
using System.Xml;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel
{
    public class CSample3Vm:ViewModelBase
    {
        private List<string> mvControls = null;
        public CSample3Vm()
        {
            this.Items = new List<string>();
            this.Items.Add("System.Windows.Controls.DatePicker");
            this.Items.Add("System.Windows.Controls.Calendar");
            this.ContentCtr = LoadControlObject("System.Windows.Controls.Button");

            this.NotifItems = new ObservableCollection<CNotifItem>();
            this.NotifItems.Add(new CNotifItem() { Name = "Item1",ID="1"});
            this.NotifItems.Add(new CNotifItem() { Name = "Item2" ,ID="2" });
            this.NotifItems.Add(new CNotifItem() { Name = "Item1", ID = "3" });
            this.NotifItems.Add(new CNotifItem() { Name = "Item2", ID = "4" });
            this.NotifItems.Add(new CNotifItem() { Name = "Item1", ID = "5" });
            this.NotifItems.Add(new CNotifItem() { Name = "Item2", ID = "6" });
            this.NotifItems.Add(new CNotifItem() { Name = "Item1", ID = "7" });
            this.NotifItems.Add(new CNotifItem() { Name = "Item2", ID = "8" });
            this.NotifItems.Add(new CNotifItem() { Name = "Item1", ID = "9" });
            this.NotifItems.Add(new CNotifItem() { Name = "Item2", ID = "10" });
            this.NotifItems.Add(new CNotifItem() { Name = "Item1", ID = "11" });
            this.NotifItems.Add(new CNotifItem() { Name = "Item2", ID = "12" });
            this.NotifItems.Add(new CNotifItem() { Name = "Item1", ID = "13" });
            this.NotifItems.Add(new CNotifItem() { Name = "Item2", ID = "14" });
            this.NotifItems.Add(new CNotifItem() { Name = "Item1", ID = "15" });
            this.NotifItems.Add(new CNotifItem() { Name = "Item2", ID = "16" });
        }
        private Control mvContentCtr;
        public Control ContentCtr
        {
            get { return mvContentCtr; }
            set
            {
                mvContentCtr = value;
                this.OnPropertyChanged(x=>x.ContentCtr);
            }
        }

        public ICommand RunPopUp
        {
            get { return new DelegateCommand(() => { IsOpenPopUp = true; }); }

        }

        public ICommand Navigate
        {
            get { return new DelegateCommand<object>((x) => { Process.Start((x as Hyperlink).NavigateUri.ToString()); }); }

        }

        private bool mvIsOpenPopUp = false;
        public bool IsOpenPopUp
        {
            get { return mvIsOpenPopUp; }
            set
            {
                mvIsOpenPopUp = value;
                this.OnPropertyChanged(x=>x.IsOpenPopUp);
            }
        }


        private ObservableCollection<CNotifItem> myNotifItems;

        public ObservableCollection<CNotifItem> NotifItems
        {
            get { return myNotifItems; }
            set { myNotifItems = value; }
        }
        
        
        public List<string> Items
        {
            get { return mvControls; }
            set
            {
                mvControls = value;
                this.OnPropertyChanged(x => x.Items);
            }
        }

        private string mvSelectedControl;
        public string SelectedControl
        {
            get { return mvSelectedControl; }
            set
            {
                mvSelectedControl = value;
                this.OnPropertyChanged(x=>x.SelectedControl);
                ContentCtr = LoadControlObject(value);
            }
        }

        private Control LoadControlObject(string name)
        {
            Assembly asm = Assembly.Load("PresentationFramework, Version=4.0.0.0," +
            "Culture=neutral, PublicKeyToken=31bf3856ad364e35");
            var ctrlToExamine = (Control)asm.CreateInstance(name);
            ctrlToExamine.Height = 200;
            ctrlToExamine.Width = 200;
            ctrlToExamine.Margin = new Thickness(5);
            // Define some XML settings to preserve indentation.
            //XmlWriterSettings xmlSettings = new XmlWriterSettings();
            //xmlSettings.Indent = true;
            //// Create a StringBuilder to hold the XAML.
            //StringBuilder strBuilder = new StringBuilder();
            //// Create an XmlWriter based on our settings.
            //XmlWriter xWriter = XmlWriter.Create(strBuilder, xmlSettings);
            //// Now save the XAML into the XmlWriter object based on the ControlTemplate.
            //XamlWriter.Save(ctrlToExamine.Template, xWriter);

            return ctrlToExamine;
        }
    }
}
