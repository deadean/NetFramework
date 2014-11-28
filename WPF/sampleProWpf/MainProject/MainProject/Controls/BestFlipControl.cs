using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ViewModelLib.Commands;

namespace MainProject.Controls
{
    public class BestFlipControl:Control
    {
        #region Ctor

        public BestFlipControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BestFlipControl), new FrameworkPropertyMetadata(typeof(BestFlipControl)));
            IsFlipped = true;
            this.DataContext = this;
        }

        public ICommand ChangeFlipCommand
        {
            get { return new DelegateCommand(() => { IsFlipped = !IsFlipped; }); }
        }

        #endregion

        #region Dependency Properties

        public object FronContent
        {
            get { return (object)GetValue(FronContentProperty); }
            set { SetValue(FronContentProperty, value); }
        }
        public static readonly DependencyProperty FronContentProperty = DependencyProperty.Register("FronContent", typeof(object), typeof(BestFlipControl), null);

        public object BackContent
        {
            get { return (object)GetValue(BackContentProperty); }
            set { SetValue(BackContentProperty, value); }
        }
        public static readonly DependencyProperty BackContentProperty = DependencyProperty.Register("BackContent", typeof(object), typeof(BestFlipControl), null);

        public bool IsFlipped
        {
            get { return (bool)GetValue(IsFlippedProperty); }
            set { SetValue(IsFlippedProperty, value); }
        }

        public static readonly DependencyProperty IsFlippedProperty = DependencyProperty.Register("IsFlipped", typeof(bool), typeof(BestFlipControl), null);

        #endregion

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

        }


    }
}
