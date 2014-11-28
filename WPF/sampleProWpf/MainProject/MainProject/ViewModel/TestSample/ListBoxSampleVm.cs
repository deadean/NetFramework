using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel.TestSample
{
    public class ListBoxSampleVm:ViewModelBase
    {
        public ListBoxSampleVm()
        {
            for (int i = 0; i < 200; i++)
            {
                Messagies.Add(new CMessage() { Text = "dddd"+i.ToString() });
            }

            Persons = new ObservableCollection<CPerson>();
            for (int i = 0; i < 100; i++)
            {
                Persons.Add(new CPerson() { Name = i.ToString()});
            }

            this.MenuItems = new ObservableCollection<CMenuItemVm>();
            this.MenuItems.Add(new CMenuItemVm() { Name = "Menu 1", ActivateCommand = new DelegateCommand(() => { MessageBox.Show("Menu 1"); }) });
        }
        private IList<CMessage> mvMessagies = new List<CMessage>();
        public IList<CMessage> Messagies
        {
            get { return mvMessagies; }
            set
            {
                mvMessagies = value;
                //this.OnPropertyChanged(x=>x.Messagies);
            }

        }

        public ICommand AddMessageCommand
        {
            get { return new DelegateCommand(() => { Messagies.Add(new CMessage() { Text = DateTime.Now.ToShortDateString() }); }); }
        }

        public ObservableCollection<CPerson> Persons { get; set; }

        public ObservableCollection<CMenuItemVm> MenuItems { get; set; }
        
    }

    public class CPerson
    {
        public string Name { get; set; }
    }

    public class CMessage
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="CMessage"/> class.
        /// </summary>
        public CMessage()
        {
        }

        

        #endregion Ctor

        #region Properties

        /// <summary>
        /// Gets or sets the conversation ID.
        /// </summary>
        /// <value>
        /// The conversation ID.
        /// </value>
        public string ConversationID { get; set; }

       
        /// Gets or sets the contact ID.
        /// </summary>
        /// <value>
        /// The contact ID.
        /// </value>
        public string ContactID { get; set; }

        

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName
        {
            get
            {
                return "Dean";
            }
        }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }

                /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }

        #endregion
    }
}
