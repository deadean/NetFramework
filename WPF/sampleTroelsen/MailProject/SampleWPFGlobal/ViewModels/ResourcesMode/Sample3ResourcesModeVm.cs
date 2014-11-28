using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels.ResourcesMode
{
    public class Sample3ResourcesModeVm:ViewModelBase
    {
        public Sample3ResourcesModeVm()
        {
            Styles.Add(new CStyle() { Name = "GrowingButtonStyle" });
            Styles.Add(new CStyle() { Name = "TiltButton" });
            Styles.Add(new CStyle() { Name = "BigGreenButton" });
            Styles.Add(new CStyle() { Name = "BasicControlStyle" });
        }

        private ObservableCollection<CStyle> mvStyles = new ObservableCollection<CStyle>();
        public ObservableCollection<CStyle> Styles
        {
            get { return mvStyles; }
            set 
            {
                mvStyles = value;
                this.OnPropertyChanged(x=>x.Styles);

            }
        }

        private CStyle mvCurrentStyle;
        public CStyle CurrrentStyle
        {
            get { return mvCurrentStyle; }
            set
            {
                mvCurrentStyle = value;
                this.OnPropertyChanged(x=>x.CurrrentStyle);

            }
        }

        public ICommand SelectStyleCommand
        {
            get
            {
                return new DelegateCommand<object>(
                    (x) =>
                    {
                        var button = x as ButtonBase;
                        if (button == null || CurrrentStyle==null)
                            return;

                        Style currStyle = (Style)Application.Current.MainWindow.TryFindResource(CurrrentStyle.Name);
                        if (currStyle != null)
                        {
                            button.Style = currStyle;
                        }
                    });
            }
        }
    }
}
