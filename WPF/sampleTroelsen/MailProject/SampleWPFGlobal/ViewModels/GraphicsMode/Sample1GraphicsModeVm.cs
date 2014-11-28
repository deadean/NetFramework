using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using ViewModelLib;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels.GraphicsMode
{
    public class Sample1GraphicsModeVm:ViewModelBase
    {
        private enum SelectedShape
        { Circle, Rectangle, Line }
        private SelectedShape currentShape;

        public Sample1GraphicsModeVm()
        {
            RectangleFill = Colors.Green.ToString();
        }

        public ICommand MouseLeftButtonDownCommand
        {
            get { return new DelegateCommand<object>((x) => 
            {
                var param = x as CBehaviourType;
                Shape shapeToRender = null;
                switch (currentShape)
                {
                    case SelectedShape.Circle:
                        //shapeToRender = new Ellipse() { Fill = Brushes.Green, Height = 35, Width = 35 };

                        shapeToRender = new Ellipse() { Height = 35, Width = 35 };
                        // Make a RadialGradientBrush in code!
                        RadialGradientBrush brush = new RadialGradientBrush();
                        brush.GradientStops.Add(new GradientStop(
                        (Color)ColorConverter.ConvertFromString("#FF87E71B"), 0.589));
                        brush.GradientStops.Add(new GradientStop(
                        (Color)ColorConverter.ConvertFromString("#FF2BA92B"), 0.013));
                        brush.GradientStops.Add(new GradientStop(
                        (Color)ColorConverter.ConvertFromString("#FF34B71B"), 1));
                        shapeToRender.Fill = brush;

                        break;
                    case SelectedShape.Rectangle:
                        shapeToRender = new Rectangle() { Fill = Brushes.Red, Height = 35, Width = 35, RadiusX = 10, RadiusY = 10 };
                        break;
                    case SelectedShape.Line:
                        shapeToRender = new Line()
                        {
                            Stroke = Brushes.Blue,
                            StrokeThickness = 10,
                            X1 = 0,
                            X2 = 50,
                            Y1 = 0,
                            Y2 = 50,
                            StrokeStartLineCap = PenLineCap.Triangle,
                            StrokeEndLineCap = PenLineCap.Round
                        };
                        break;
                    default:
                        return;
                }

                var mouseArgs = param.MouseEventArguments as MouseEventArgs;
                Canvas.SetLeft(shapeToRender, mouseArgs.GetPosition(param.PanelTarget).X);
                Canvas.SetTop(shapeToRender, mouseArgs.GetPosition(param.PanelTarget).Y);

                param.PanelTarget.Children.Add(shapeToRender);

            }); }
        }

        public ICommand MouseRightButtonDownCommand
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {
                    var param = x as CBehaviourType;
                    var canvas = (Canvas)param.Sender;
                    var mouseArgs = param.MouseEventArguments as MouseEventArgs;
                    Point pt = mouseArgs.GetPosition(canvas);
                    HitTestResult result = VisualTreeHelper.HitTest(canvas, pt);
                    if (result != null)
                    {
                        canvas.Children.Remove(result.VisualHit as Shape);
                    }
                });
            }
        }

        public ICommand MouseEnterCommand
        {
            get { return new DelegateCommand(() => 
            {
                RectangleFill = Colors.AliceBlue.ToString();
            }); }
        }

        private string mvRectangleFill;
        public string RectangleFill
        {
            get { return mvRectangleFill; }
            set
            {
                mvRectangleFill = value;
                
                this.OnPropertyChanged(x=>x.RectangleFill);
            }
        }

        private string mvIsCircle;
        public string IsCircle
        {
            get { return mvIsCircle; }
            set
            {
                this.currentShape = SelectedShape.Circle;
                mvIsCircle = value;
                this.OnPropertyChanged(x => x.IsCircle);
            }
        }

        private string mvIsRectangle;
        public string IsRectangle
        {
            get { return mvIsRectangle; }
            set
            {
                this.currentShape = SelectedShape.Rectangle;
                mvIsRectangle = value;
                this.OnPropertyChanged(x => x.IsRectangle);
            }
        }

        private string mvIsLine;
        public string IsLine
        {
            get { return mvIsLine; }
            set
            {
                this.currentShape = SelectedShape.Line;
                mvIsLine = value;
                this.OnPropertyChanged(x => x.IsLine);
            }
        }

    }
}
