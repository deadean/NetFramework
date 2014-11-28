using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel
{
    public class CSample15Vm : ViewModelBase
    {
        private List<EllipseInfo> ellipses = new List<EllipseInfo>();
        private double accelerationY = 0.1;
        private int minStartingSpeed = 1;
        private int maxStartingSpeed = 50;
        private double speedRatio = 0.1;
        private int minEllipses = 20;
        private int maxEllipses = 100;
        private int ellipseRadius = 10;
        private bool rendering = false;

        public CSample15Vm()
        {
            IsRectangleVisible = true;
        }
        private bool mvIsRectangleVisible;
        public bool IsRectangleVisible
        {
            get { return mvIsRectangleVisible; }
            set { mvIsRectangleVisible = value; this.OnPropertyChanged(x=>x.IsRectangleVisible); }
        }

        public ICommand StartCommand
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                    {
                        if (!rendering || !(x is Canvas))
                        {
                            ellipses.Clear();
                            (x as Canvas).Children.Clear();
                            InstanceCanvas = x as Canvas;
                            CompositionTarget.Rendering += RenderFrame;
                            rendering = true;
                        }
                    });
            }
        }

        public ICommand StartCommand1
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {
                    if (x is Button)
                    {
                        InstanceButton = x as Button;
                        CompositionTarget.Rendering += RenderFrame1;
                    }
                });
            }
        }

        public ICommand StartCommand2
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {
                    if (x is Border)
                    {
                        InstanceBorder = x as Border;
                        GetBorderStoryBoard().Begin();
                    }
                });
            }
        }

        private Canvas InstanceCanvas { get; set; }
        private Button InstanceButton { get; set; }
        private Border InstanceBorder { get; set; }
        private Button InstanceTextBlock { get; set; }

        private Storyboard GetBorderStoryBoard()
        {
            return this.TryCatch(() => 
            {
                var storyBoard = new Storyboard();

                DoubleAnimation an1 = new DoubleAnimation();
                an1.From = 100;
                an1.To = 200;
                an1.Duration = TimeSpan.FromSeconds(5);

                Storyboard.SetTarget(an1,InstanceBorder);
                Storyboard.SetTargetProperty(an1,new PropertyPath("Width"));
                storyBoard.Children.Add(an1);

                return storyBoard;
            },
            new Storyboard(),
            "GetBorderStoryBoard");
        }


        public ICommand StopCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {

                });
            }
        }

        static int dif = 1;
        private void RenderFrame1(object sender, EventArgs e)
        {
            var max = 300;
            var min = 100;

            if (InstanceButton.Width >= max)
                dif = -1;
            if (InstanceButton.Width <= min)
                dif = 1;

            InstanceButton.Width += dif;
        }


        private void RenderFrame(object sender, EventArgs e)
        {
            if (ellipses.Count == 0)
            {
                // Animation just started. Create the ellipses.
                int halfCanvasWidth = (int)InstanceCanvas.ActualWidth / 2;
                Random rand = new Random();
                int ellipseCount = rand.Next(minEllipses, maxEllipses + 1);
                for (int i = 0; i < ellipseCount; i++)
                {
                    // Create the ellipse.
                    Ellipse ellipse = new Ellipse();
                    ellipse.Fill = Brushes.LimeGreen;
                    ellipse.Width = ellipseRadius;
                    ellipse.Height = ellipseRadius;
                    // Place the ellipse.
                    Canvas.SetLeft(ellipse, halfCanvasWidth +
                    rand.Next(-halfCanvasWidth, halfCanvasWidth));
                    Canvas.SetTop(ellipse, 0);
                    InstanceCanvas.Children.Add(ellipse);
                    // Track the ellipse.
                    EllipseInfo info = new EllipseInfo(ellipse,
                    speedRatio * rand.Next(minStartingSpeed, maxStartingSpeed));
                    ellipses.Add(info);
                }
            }
            else
            {
                for (int i = ellipses.Count - 1; i >= 0; i--)
                {
                    EllipseInfo info = ellipses[i];
                    double top = Canvas.GetTop(info.Ellipse);
                    Canvas.SetTop(info.Ellipse, top + 1 * info.VelocityY);
                    if (top >= (InstanceCanvas.ActualHeight - ellipseRadius * 2))
                    {
                        // This circle has reached the bottom.
                        // Stop animating it.
                        ellipses.Remove(info);
                    }
                    else
                    {
                        // Increase the velocity.
                        info.VelocityY += accelerationY;
                    }
                    if (ellipses.Count == 0)
                    {
                        // End the animation.
                        // There's no reason to keep calling this method
                        // if it has no work to do.
                        //CompositionTarget.Rendering -= RenderFrame;
                        //rendering = false;
                    }
                }
            }
        }


        public class EllipseInfo
        {
            public Ellipse Ellipse
            {
                get;
                set;
            }
            public double VelocityY
            {
                get;
                set;
            }
            public EllipseInfo(Ellipse ellipse, double velocityY)
            {
                VelocityY = velocityY;
                Ellipse = ellipse;
            }
        }
    }
}
