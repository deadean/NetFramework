using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels
{
    public class Sample5Tab1Vm:ViewModelBase
    {
        public Sample5Tab1Vm()
        {
            Colors = new ObservableCollection<CColor>();
            Colors.Add(new CColor() { Color = Color.FromArgb(255,0,0,255), Name="Color1", Height=20, FitToCurve=true, Width=3});
            Colors.Add(new CColor() { Color = Color.FromArgb(255, 255, 0, 255), Name = "Color2", Height = 20, FitToCurve = false });
            Colors.Add(new CColor() { Color = Color.FromArgb(255, 255, 0, 0), Name = "Color3", Height = 20, FitToCurve = true });

            EditingModes = new ObservableCollection<string>();
            EditingModes.Add("EraseByPoint");
            EditingModes.Add("EraseByStroke");
            EditingModes.Add("GestureOnly");
            EditingModes.Add("Ink");
            EditingModes.Add("InkAndGesture");
            EditingModes.Add("None");
            EditingModes.Add("Select");
        }
        public ICommand TestCommand
        {
            get { return new DelegateCommand(() => { MessageBox.Show("test"); }); }
        }

        public ICommand SaveCommand
        {
            get { return new DelegateCommand<object>((x) => 
            {
                var strokes = x as StrokeCollection;
                if (strokes == null)
                    return;

                using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Create))
                {
                    strokes.Save(fs);
                    fs.Close();
                }
            }); }
        }

        public ICommand LoadCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    using (FileStream fs = new FileStream("StrokeData.bin",FileMode.Open, FileAccess.Read))
                    {
                        CanvasStrokes = new StrokeCollection(fs);
                    }
                });
            }
        }

        public ICommand ClearCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    CanvasStrokes.Clear();
                });
            }
        }

        private bool mvIsInkRadio = true;
        public bool IsInkRadio
        {
            get { return mvIsInkRadio; }
            set { mvIsInkRadio = value; this.OnPropertyChanged(x=>x.IsInkRadio); }
        }



        private StrokeCollection mvCanvasStrokes;
        public StrokeCollection CanvasStrokes
        {
            get { return mvCanvasStrokes; }
            set
            {
                mvCanvasStrokes = value;
                this.OnPropertyChanged(x => x.CanvasStrokes);
            }
        }

        private ObservableCollection<CColor> mvColors;
        public ObservableCollection<CColor> Colors
        {
            get { return mvColors; }
            set
            {
                mvColors = value;
                this.OnPropertyChanged(x => x.Colors);
            }
        }

        private ObservableCollection<string> mvEditingModes;
        public ObservableCollection<string> EditingModes
        {
            get { return mvEditingModes; }
            set
            {
                mvEditingModes = value;
                this.OnPropertyChanged(x => x.EditingModes);
            }
        }

        private CColor mvSelectedItem;
        public CColor SelectedColor
        {
            get { return mvSelectedItem; }
            set 
            { 
                mvSelectedItem = value;
                this.OnPropertyChanged(x=>x.SelectedColor);
            }
        }

        private string mvEditMode;
        public string EditMode
        {
            get { return mvEditMode; }
            set
            {
                mvEditMode = value;
                this.OnPropertyChanged(x => x.EditMode);
            }
        }

    }
}
