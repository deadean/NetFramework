using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels.GraphicsMode
{
    public class Sample5GraphicsModeVm:ViewModelBase
    {



        private RenderTargetBitmap mvBitMap;
        public RenderTargetBitmap ImageSource 
        {
            get { return mvBitMap; }
            set
            {
                mvBitMap = value;
                this.OnPropertyChanged(x => x.ImageSource);
            }
        }

        public ICommand LoadedCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    const int TextFontSize = 30;
                    FormattedText text = new FormattedText("Hello Visual Layer!",new System.Globalization.CultureInfo("en-us"),FlowDirection.LeftToRight,
                        new Typeface(new System.Windows.Media.FontFamily("Comic Sans MS"), FontStyles.Italic,FontWeights.DemiBold, FontStretches.UltraExpanded),TextFontSize,System.Windows.Media.Brushes.Green);

                    DrawingVisual drawingVisual = new DrawingVisual();
                    using(DrawingContext drawingContext = drawingVisual.RenderOpen())
                    {
                        drawingContext.DrawRoundedRectangle(System.Windows.Media.Brushes.Yellow, new System.Windows.Media.Pen(System.Windows.Media.Brushes.Black, 5),
                            new Rect(5, 5, 450, 100), 20, 20);
                        //drawingContext.DrawText(text, new System.Windows.Point(20, 20));
                    }

                    RenderTargetBitmap bmp = new RenderTargetBitmap(100, 100, 100, 10,PixelFormats.Pbgra32);
                    bmp.Render(drawingVisual);

                    ImageSource = bmp;
                });
            }
        }
    }
}
