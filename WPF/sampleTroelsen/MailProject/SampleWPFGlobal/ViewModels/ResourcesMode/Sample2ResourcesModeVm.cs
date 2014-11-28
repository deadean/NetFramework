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
using System.Windows.Media;
using System.Windows.Media.Animation;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels.ResourcesMode
{
    public class Sample2ResourcesModeVm:ViewModelBase
    {
        private bool isSpining = false;
        public Sample2ResourcesModeVm()
        {
            ButtonAnimations.Add(new CAnimation()
            {
                Name = "Animation1",
                Action = new Func<ButtonBase,bool>((x) =>
                {
                    bool res = false;
                    if (x != null)
                    {
                        res = true;
                        // Make a double animation object, and register
                        // with the Completed event.
                        DoubleAnimation dblAnim = new DoubleAnimation();
                        dblAnim.Completed += (o, s) => { res = false; };
                        // Set the start value and end value.
                        dblAnim.From = 0;
                        dblAnim.To = 360;

                        // Loop forever.
                        //dblAnim.RepeatBehavior = RepeatBehavior.Forever;
                        // Loop three times.
                        dblAnim.RepeatBehavior = new RepeatBehavior(3);
                        // Loop for 30 seconds.
                        //dblAnim.RepeatBehavior = new RepeatBehavior(TimeSpan.FromSeconds(30));

                        // Now, create a RotateTransform object, and set
                        // it to the RenderTransform property of our
                        // button.
                        RotateTransform rt = new RotateTransform();
                        x.RenderTransform = rt;
                        // Now, animation the RotateTransform object.
                        rt.BeginAnimation(RotateTransform.AngleProperty, dblAnim);
                    }
                    return false;
                })
            });

            ButtonAnimations.Add(new CAnimation()
            {
                Name = "Animation2",
                Action = new Func<ButtonBase, bool>((x) =>
                {
                    isSpinning = true;
                    // Make a double animation object, and register
                    // with the Completed event.
                    DoubleAnimation dblAnim = new DoubleAnimation();
                    dblAnim.Completed += (o, s) => { isSpinning = false; };

                    dblAnim.From = 0;
                    dblAnim.To = 360;

                    // Button has four seconds to finish the spin!
                    dblAnim.Duration = new Duration(TimeSpan.FromSeconds(4));
                    x.BeginAnimation(RotateTransform.AngleProperty, dblAnim);
                    return false;
                })
            });

            ButtonAnimations.Add(new CAnimation()
            {
                Name = "Animation3",
                Action = new Func<ButtonBase, bool>((x) =>
                {
                    DoubleAnimation dblAnim = new DoubleAnimation();
                    dblAnim.From = 1.0;
                    dblAnim.To = 0.0;
                    x.BeginAnimation(Button.OpacityProperty, dblAnim);
                    return false;
                })
            });

            ButtonAnimations.Add(new CAnimation()
            {
                Name = "Animation4",
                Action = new Func<ButtonBase, bool>((x) =>
                {
                    DoubleAnimation dblAnim = new DoubleAnimation();
                    dblAnim.From = 1.0;
                    dblAnim.To = 0.0;
                    // Reverse when done.
                    dblAnim.AutoReverse = true;
                    x.BeginAnimation(Button.OpacityProperty, dblAnim);
                    return false;
                })
            });

            CurrentAnimation = ButtonAnimations.FirstOrDefault();

        }

        private bool isSpinning = false;
        public ICommand MouseEnterCommand
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {
                    var button = x as ButtonBase;
                    if(!isSpining)
                        isSpining = CurrentAnimation.Action.Invoke(button);
                    
                });
            }
        }

        private ObservableCollection<CAnimation> mvAnimationSource = new ObservableCollection<CAnimation>();
        public ObservableCollection<CAnimation> ButtonAnimations
        {
            get { return mvAnimationSource; }
            set
            {
                mvAnimationSource = value;
                this.OnPropertyChanged(x=>x.ButtonAnimations);
            }
        }

        private CAnimation mvCurrentAnimation;
        public CAnimation CurrentAnimation
        {
            get { return mvCurrentAnimation; }
            set
            {
                mvCurrentAnimation = value;
                this.OnPropertyChanged(x=>x.CurrentAnimation);
            }
        }

    }
}
