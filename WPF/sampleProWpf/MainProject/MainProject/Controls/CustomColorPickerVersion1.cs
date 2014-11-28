using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModelLib.Commands;

namespace MainProject.Controls
{
    /// <summary>
    /// Interaction logic for CustomColorPickerVersion1.xaml
    /// </summary>
    [TemplatePart(Name = "PART_RedSlider", Type = typeof(RangeBase))]
    [TemplatePart(Name = "PART_BlueSlider", Type = typeof(RangeBase))]
    [TemplatePart(Name = "PART_GreenSlider", Type = typeof(RangeBase))]
    public class CustomColorPickerVersion1 : System.Windows.Controls.Control
    {
        public CustomColorPickerVersion1()
        {
            //InitializeComponent();
            SetUpCommands();
        }

        static CustomColorPickerVersion1()
        {
            CommandManager.RegisterClassCommandBinding(typeof(CustomColorPickerVersion1), new CommandBinding(ApplicationCommands.Redo, RedoCommand_Executed, RedoCommand_CanExecute));
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomColorPickerVersion1), new FrameworkPropertyMetadata(typeof(CustomColorPickerVersion1)));
        }

        private void SetUpCommands()
        {
            CommandBinding binding = new CommandBinding(ApplicationCommands.Undo, UndoCommand_Executed, UndoCommand_CanExecute);
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(DataCommands.Requery);
            binding.Executed += (x, y) => { MessageBox.Show("Command Requery is fired! From ColorPicker Control"); };
            binding.CanExecute += (x, y) => { y.CanExecute = true; };
            this.CommandBindings.Add(binding);
        }

        public Color? previousColor;
        private void UndoCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = previousColor.HasValue;
        }

        private void UndoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Color = (Color)previousColor;
        }

        private static void RedoCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            CustomColorPickerVersion1 colorPicker = (CustomColorPickerVersion1)sender;
            e.CanExecute = colorPicker.previousColor.HasValue;
        }

        private static void RedoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CustomColorPickerVersion1 colorPicker = (CustomColorPickerVersion1)sender;
            Color currentColor = colorPicker.Color;
            colorPicker.Color = (Color)colorPicker.previousColor;
        }

        #region Routed Events

        public static readonly RoutedEvent ColorChangedEvent =
            EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<Color>), typeof(CustomColorPickerVersion1));
        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        #endregion

        #region Properties

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Color), typeof(CustomColorPickerVersion1), new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            Color oldColor = (Color)e.OldValue;
            CustomColorPickerVersion1 colorPicker = (CustomColorPickerVersion1)d;
            colorPicker.Red = newColor.R;
            colorPicker.Green = newColor.G;
            colorPicker.Blue = newColor.B;
            colorPicker.previousColor = oldColor;
        }

        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Red.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RedProperty =
            DependencyProperty.Register("Red", typeof(byte), typeof(CustomColorPickerVersion1), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnRedChanged)));

        private static void OnRedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            OnColorRGBChanged(d, e);
        }

        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Green.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GreenProperty =
            DependencyProperty.Register("Green", typeof(byte), typeof(CustomColorPickerVersion1), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnGreenChanged)));

        private static void OnGreenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            OnColorRGBChanged(d, e);
        }

        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Blue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BlueProperty =
            DependencyProperty.Register("Blue", typeof(byte), typeof(CustomColorPickerVersion1), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnBlueChanged)));

        private static void OnBlueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            OnColorRGBChanged(d, e);
        }

        #endregion

        #region Private Services

        private static void OnColorRGBChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var controlInstance = (CustomColorPickerVersion1)d;
            var color = controlInstance.Color;

            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;
            controlInstance.Color = color;

            if (ColorChangedEvent != null)
            {
                RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>(controlInstance.Color, color);
                args.RoutedEvent = CustomColorPicker.ColorChangedEvent;
                controlInstance.RaiseEvent(args);
            }
        }

        #endregion

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            RangeBase slider = GetTemplateChild("PART_RedSlider") as RangeBase;
            if (slider != null)
            {
                Binding binding = new Binding("Red");
                binding.Source = this;
                binding.Mode = BindingMode.TwoWay;
                slider.SetBinding(RangeBase.ValueProperty, binding);
            }
            RangeBase slider1 = GetTemplateChild("PART_GreenSlider") as RangeBase;
            if (slider != null)
            {
                Binding binding = new Binding("Green");
                binding.Source = this;
                binding.Mode = BindingMode.TwoWay;
                slider1.SetBinding(RangeBase.ValueProperty, binding);
            }
            RangeBase slider2 = GetTemplateChild("PART_BlueSlider") as RangeBase;
            if (slider != null)
            {
                Binding binding = new Binding("Blue");
                binding.Source = this;
                binding.Mode = BindingMode.TwoWay;
                slider2.SetBinding(RangeBase.ValueProperty, binding);
            }
            SolidColorBrush brush = GetTemplateChild("PART_PreviewBrush") as SolidColorBrush;
            if (brush != null)
            {
                Binding binding = new Binding("Color");
                binding.Source = brush;
                binding.Mode = BindingMode.OneWayToSource;
                this.SetBinding(CustomColorPickerVersion1.ColorProperty, binding);
            }
        }
    }
}
