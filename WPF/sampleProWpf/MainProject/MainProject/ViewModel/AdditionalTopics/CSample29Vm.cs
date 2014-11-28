using MainProject.View.AdditionalTopics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel.AdditionalTopics
{
    public class CSample29Vm:ViewModelBase
    {
        #region Fields
        #endregion

        #region Ctor

        public CSample29Vm()
        {
            Command1 = new DelegateCommand(OnCommand1);
        }

        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion

        #region Protected Methods
        #endregion

        #region Properties
        #endregion

        #region Commands

        public DelegateCommand Command1 { get; set; }

        #endregion

        #region Commands Execute Handlers

        private void OnCommand1()
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }

        #endregion

        #region Message Handlers
        #endregion

        #region Events Handlers
        #endregion
    }
}
