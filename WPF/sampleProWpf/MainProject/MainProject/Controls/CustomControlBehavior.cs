using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MainProject.Controls
{
    public static class CustomControlBehavior
    {
        #region ColorChanged

        public static readonly DependencyProperty OnColorChangedCommand = DependencyProperty.RegisterAttached
            ("ColorChanged", typeof(ICommand), typeof(CustomControlBehavior), new FrameworkPropertyMetadata(null, OnColorChanged));

        public static void SetColorChanged(CustomColorPicker content, ICommand comm)
        {
            content.SetValue(OnColorChangedCommand, comm);
        }

        public static ICommand GetColorChanged(CustomColorPicker content)
        {
            return content.GetValue(OnColorChangedCommand) as ICommand;
        }

        private static void OnColorChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            try
            {
                var content = dependencyObject as CustomColorPicker;

                if (content == null)
                    return;

                var command = args.NewValue as ICommand;

                content.ColorChanged -= OnValue;

                if (command == null)
                    return;

                content.ColorChanged += OnValue;
            }
            catch { }
        }

        private static void OnValue(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            var content = sender as CustomColorPicker;

            if (content == null)
                return;

            var command = GetColorChanged(content);

            if (command == null)
                return;

            if (command.CanExecute(content.Color))
            {
                command.Execute(content.Color);
            }
        }

        #endregion
    }
}
