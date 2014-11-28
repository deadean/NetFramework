using MainProject.View;
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
using System.Windows.Media.Animation;
using System.Windows.Threading;
using ViewModelLib;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel
{
    public class CSample18Vm:ViewModelBase
    {
        private DispatcherTimer modTimer = new DispatcherTimer();
        #region Properties

        public CSample18 Instance { get; set; }

        private int mvCountClickedBombs;

        public int CountClickedBombs
        {
            get { return mvCountClickedBombs; }
            set { mvCountClickedBombs = value; this.OnPropertyChanged(x => x.CountClickedBombs); }
        }

        private int mvCurrentValue;

        public int CurrentValue
        {
            get { return mvCurrentValue; }
            set { mvCurrentValue = value; this.OnPropertyChanged(x => x.CurrentValue); }
        }
        
        

        #endregion

        #region Commands

        public ICommand StartCommand
        {
            get { return new DelegateCommand(GenerateNewControls); }
        }

        public ICommand ClickCommand
        {
            get { return new DelegateCommand<object>((x) => 
            {
                Instance.ctrCanvas.Children.Remove((x as CBehaviourType).Sender as UIElement); CountClickedBombs++; CurrentValue++;
            });
            
            }
        }

        #endregion

        #region Private Services

        private void GenerateNewControls()
        {
            CurrentValue = 30;
            modTimer = new DispatcherTimer();
            modTimer.Interval = TimeSpan.FromSeconds(2);
            modTimer.Tick += (x, y) => 
            {
                if (CountClickedBombs == 5)
                    modTimer.Interval = TimeSpan.FromSeconds(.5);
                if(CountClickedBombs==30)
                    modTimer.Interval = TimeSpan.FromSeconds(.4);
                Random rnd = new Random();
                Button btn = new Button();
                btn.Height = 25;
                btn.Width = 100;
                btn.SetValue(Canvas.LeftProperty, (double)rnd.Next(0, 750));
                btn.Content = DateTime.Now.ToString();
                btn.Style = Instance.ctrCanvas.FindResource("styleAn") as Style;
                CurrentValue--;
                Instance.ctrCanvas.Children.Add(btn);
                if (CurrentValue == 0)
                {
                    modTimer.Stop();
                    modTimer = null;
                    MessageBox.Show("You are lost!");
                }
            };
            modTimer.Start();
            
        }

        #endregion

    }
}
