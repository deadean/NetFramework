using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel
{
    public class CSample14Vm : ViewModelBase
    {
        private ICommand mvRepeatClick;
        private string mvTextClick;
        public class CControlItem
        {
            public string Name { get; set; }
            public Type CurrentType { get; set; }
        }




        public CSample14Vm()
        {
            InitializeControls();
            mvRepeatClick = new DelegateCommand(OnRepeatClickCommand);

        }

        private void OnRepeatClickCommand()
        {
            TextClick += "New";
        }

        private void InitializeControls()
        {
            Controls = new ObservableCollection<CControlItem>();
            Type controlType = typeof(Control);
            List<Type> derivedTypes = new List<Type>();
            // Search all the types in the assembly where the Control class is defined.
            Assembly assembly = Assembly.GetAssembly(typeof(Control));
            foreach (Type type in assembly.GetTypes())
            {
                // Only add a type of the list if it's a Control, a concrete class,
                // and public.
                if (type.IsSubclassOf(controlType) && !type.IsAbstract && type.IsPublic)
                {
                    derivedTypes.Add(type);
                }
            }
            derivedTypes.Select(x => new CControlItem() { CurrentType = x, Name = x.Name }).ToList().ForEach(x => Controls.Add(x));
            ListBoxItems = new ObservableCollection<string>();
            ListBoxItems.Add("Item 1");
            ListBoxItems.Add("Item 2");
            ListBoxItems.Add("Item 3");
            ListBoxItems.Add("Item 1");
            ListBoxItems.Add("Item 2");
            ListBoxItems.Add("Item 3");
            ListBoxItems.Add("Item 1");
            ListBoxItems.Add("Item 2");
            ListBoxItems.Add("Item 3");
        }

        public ObservableCollection<CControlItem> Controls { get; set; }
        public ObservableCollection<string> ListBoxItems { get; set; }

        private CControlItem mvControl;
        public CControlItem CurrentControl
        {
            get { return mvControl; }
            set { 
                mvControl = value;
            }
        }

        private string mvText = String.Empty;
        public string Text
        {
            get { return mvText; }
            set
            {
                mvText = value;
                this.OnPropertyChanged(x => x.Text);
            }
        }

        public string TextClick
        {
            get { return mvTextClick; }
            set
            {
                mvTextClick = value;
                this.OnPropertyChanged(x => x.TextClick);
            }
        }

        public ICommand RepeatClick
        {
            get { return mvRepeatClick; }
        }
    }

}
