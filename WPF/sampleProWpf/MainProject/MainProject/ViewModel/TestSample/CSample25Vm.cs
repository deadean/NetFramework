using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelLib;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel.TestSample
{
    public class CSample25Vm:ViewModelBase
    {
        #region Fields

        private ICommand modAsyncChangeLabelsCommand;

        #endregion

        #region Ctor

        public CSample25Vm()
        {
            WaitForAllThreadsCommand = new DelegateCommand(OnWaitForAllThreadsCommand);
            Command1 = new DelegateCommand(OnCommand1); Text5 = "Text 5";
        }

        #endregion

        #region Private Services

        private void UpdateText5()
        {
            Text5 = "Update Text 5";
        }

        private async void OnAsyncChangeLabelsCommand()
        {
            ChangeLabel();
            ChangeLabel1();
        }

        private async Task ChangeLabel()
        {
            for (int i = 0; i < 10; i++)
            {
                Text1 = DateTime.Now.ToString();
                await Task.Delay(1000).ConfigureAwait(continueOnCapturedContext:false);
            }
        }

        private async Task ChangeLabel1()
        {
            for (int i = 0; i < 10; i++)
            {
                Text2 = DateTime.Now.ToString();
                await Task.Delay(1000);
            }
        }

        private void OnWaitForAllThreadsCommand()
        {
            AutoResetEvent event3 = new AutoResetEvent(false);
            Thread th3 = new Thread(new ParameterizedThreadStart(ChangeLabel3));
            th3.ApartmentState = ApartmentState.MTA;
            th3.IsBackground = true;
            th3.Start(event3);

            AutoResetEvent event4 = new AutoResetEvent(false);
            Thread th4 = new Thread(new ParameterizedThreadStart(ChangeLabel4));
            th4.ApartmentState = ApartmentState.MTA;
            th4.IsBackground = true;
            th4.Start(event4);

            var events = new WaitHandle[2];
            events[0] = event3;
            events[1] = event4;

            csFunctionsGUI.Wait(events);

            //////STEP 2: Register for the events to wait for
            //int index = WaitHandle.WaitAny(events,0); //wait here for any event and print following line.

            //TextInfo34 = "One Item has finished work";

            //WaitHandle.WaitAny(events,0); //Wait for all of the threads to finish, that is, to call their cooresponding `.Set()` method.

            TextInfo34 = "All have finished";

        }

        private void ChangeLabel3(object p)
        {
                for (int i = 0; i < 5; i++)
                {
                    Text3 = DateTime.Now.ToString();
                    Thread.Sleep(1000);
                }
                p.WithType<AutoResetEvent>(x => x.Set());
        }

        private void ChangeLabel4(object p)
        {
                for (int i = 0; i < 5; i++)
                {
                    Text4 = DateTime.Now.ToString();
                    Thread.Sleep(1000);
                }
                p.WithType<AutoResetEvent>(x => x.Set());
        }

        #endregion

        #region Public Services

        #endregion

        #region Properties

        private string mvText1;

        public string Text1
        {
            get { return mvText1; }
            set { mvText1 = value; this.OnPropertyChanged(x => x.Text1); }
        }

        private string mvText2;

        public string Text2
        {
            get { return mvText2; }
            set { mvText2 = value; this.OnPropertyChanged(x => x.Text2); }
        }

        private string mvText3;

        public string Text3
        {
            get { return mvText3; }
            set { mvText3 = value; this.OnPropertyChanged(x => x.Text3); }
        }

        private string mvText4;

        public string Text4
        {
            get { return mvText4; }
            set { mvText4 = value; this.OnPropertyChanged(x => x.Text4); }
        }

        private string mvTextInfo34;

        public string TextInfo34
        {
            get { return mvTextInfo34; }
            set { mvTextInfo34 = value; this.OnPropertyChanged(x => x.TextInfo34); }
        }

        private string mvText5;

        public string Text5
        {
            get { return mvText5; }
            set { mvText5 = value; this.OnPropertyChanged(x => x.Text5); }
        }
        

        #endregion

        #region Commands

        public ICommand AsyncChangeLabelsCommand { get { return modAsyncChangeLabelsCommand ?? new DelegateCommand(OnAsyncChangeLabelsCommand); } }
        public ICommand WaitForAllThreadsCommand { get; set; }

        public DelegateCommand Command1 { get; set; }

        #endregion

        #region Commands Execute Handlers

        private void OnCommand1()
        {
            Thread th = new Thread(UpdateText5);
            th.Start();
        }

        #endregion

    }
}
