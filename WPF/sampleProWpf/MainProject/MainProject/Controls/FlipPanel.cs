using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MainProject.Controls
{
    [TemplateVisualState(Name = "Normal", GroupName = "ViewStates")]
    [TemplateVisualState(Name = "Flipped", GroupName = "ViewStates")]
    [TemplatePart(Name = "FlipButton", Type = typeof(ToggleButton))]
    [TemplatePart(Name = "FlipButtonAlternate", Type = typeof(ToggleButton))]
    public class FlipPanel:Control
    {
        #region Ctor

        static FlipPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlipPanel), new FrameworkPropertyMetadata(typeof(FlipPanel)));
        }

        #endregion

        #region Dependency Properties

        public object FronContent
        {
            get { return (object)GetValue(FronContentProperty); }
            set { SetValue(FronContentProperty, value); }
        }
        public static readonly DependencyProperty FronContentProperty = DependencyProperty.Register("FronContent", typeof(object), typeof(FlipPanel), null);

        public object BackContent
        {
            get { return (object)GetValue(BackContentProperty); }
            set { SetValue(BackContentProperty, value); }
        }
        public static readonly DependencyProperty BackContentProperty = DependencyProperty.Register("BackContent", typeof(object), typeof(FlipPanel), null);

        public bool IsFlipped
        {
            get { return (bool)GetValue(IsFlippedProperty); }
            set { SetValue(IsFlippedProperty, value); ChangeVisualState(value); }
        }

        public static readonly DependencyProperty IsFlippedProperty = DependencyProperty.Register("IsFlipped", typeof(bool), typeof(FlipPanel), null);

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(FlipPanel), null);

        #endregion

        #region Private Services

        private void ChangeVisualState(bool useTransitions)
        {
            if (!IsFlipped)
            {
                VisualStateManager.GoToState(this, "Normal", useTransitions);
                //(FronContent as FrameworkElement).Visibility = Visibility.Collapsed;
                //(BackContent as FrameworkElement).Visibility = Visibility.Visible;
            }
            else
            {
                //(BackContent as FrameworkElement).Visibility = Visibility.Collapsed;
                //(FronContent as FrameworkElement).Visibility = Visibility.Visible;
                VisualStateManager.GoToState(this, "Flipped", useTransitions);
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ToggleButton flipButton = base.GetTemplateChild("FlipButton") as ToggleButton;
            if (flipButton != null) flipButton.Click += flipButton_Click;
            // Allow for two flip buttons if needed (one for each side of the panel).
            ToggleButton flipButtonAlternate =
            base.GetTemplateChild("FlipButtonAlternate") as ToggleButton;
            if (flipButtonAlternate != null) flipButtonAlternate.Click += flipButton_Click;
            // Make sure the visuals match the current state.
            this.ChangeVisualState(false);
        }

        private void flipButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsFlipped = !this.IsFlipped;
            ChangeVisualState(true);
        }

        #endregion
    }
}
