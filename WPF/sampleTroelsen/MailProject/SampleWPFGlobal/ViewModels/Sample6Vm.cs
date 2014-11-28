using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels
{
    public class Sample6Vm:ViewModelBase
    {

        public Sample6Vm()
        {
            BackGround = new SolidColorBrush(Color.FromArgb(255,0,0,0));
        }

        private Brush mvBackGround;
        public Brush BackGround
        {
            get { return mvBackGround; }
            set
            {
                mvBackGround = value;
                this.OnPropertyChanged(x=>x.BackGround);
            }
        }

        private double mvGreenValue;
        public double GreenValue
        {
            get { return mvGreenValue; }
            set
            {
                mvGreenValue = value;
                this.OnPropertyChanged(x=>x.GreenValue);

                Color color = (BackGround as SolidColorBrush).Color;
                color.G = (byte)value;
                BackGround = new SolidColorBrush(color);
            }
        }

        private double mvRedValue;
        public double RedValue
        {
            get { return mvRedValue; }
            set
            {
                mvRedValue = value;
                this.OnPropertyChanged(x => x.RedValue);

                Color color = (BackGround as SolidColorBrush).Color;
                color.R = (byte)value;
                BackGround = new SolidColorBrush(color);
            }
        }

        private double mvBlueValue;
        public double BlueValue
        {
            get { return mvBlueValue; }
            set
            {
                mvBlueValue = value;
                this.OnPropertyChanged(x => x.BlueValue);

                Color color = (BackGround as SolidColorBrush).Color;
                color.B = (byte)value;
                BackGround = new SolidColorBrush(color);
            }
        }
    }
}
