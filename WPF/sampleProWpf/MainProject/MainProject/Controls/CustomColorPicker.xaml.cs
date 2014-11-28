using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// Interaction logic for CustomColorPicker.xaml
    /// </summary>
    public partial class CustomColorPicker : UserControl
    {
        public CustomColorPicker()
        {
            InitializeComponent();
            SetUpCommands();
        }

        static CustomColorPicker()
        {
            CommandManager.RegisterClassCommandBinding(typeof(CustomColorPicker), new CommandBinding(ApplicationCommands.Redo, RedoCommand_Executed, RedoCommand_CanExecute));
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
            CustomColorPicker colorPicker = (CustomColorPicker)sender;
            e.CanExecute = colorPicker.previousColor.HasValue;
        }

        private static void RedoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CustomColorPicker colorPicker = (CustomColorPicker)sender;
            Color currentColor = colorPicker.Color;
            colorPicker.Color = (Color)colorPicker.previousColor;
        }

        #region Routed Events

        public static readonly RoutedEvent ColorChangedEvent = 
            EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<Color>), typeof(CustomColorPicker));
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
            DependencyProperty.Register("Color", typeof(Color), typeof(CustomColorPicker), new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            Color oldColor = (Color)e.OldValue;
            CustomColorPicker colorPicker = (CustomColorPicker)d;
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
            DependencyProperty.Register("Red", typeof(byte), typeof(CustomColorPicker), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnRedChanged)));

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
            DependencyProperty.Register("Green", typeof(byte), typeof(CustomColorPicker), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnGreenChanged)));

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
            DependencyProperty.Register("Blue", typeof(byte), typeof(CustomColorPicker), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnBlueChanged)));

        private static void OnBlueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            OnColorRGBChanged(d,e);
        }


        public new ICommand OnMouseEnter
        {
            get { return (ICommand)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.RegisterAttached("OnMouseEnter", typeof(ICommand), typeof(CustomColorPicker), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnMyPropertyChanged)));

        private static void OnMyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var command = e.NewValue as ICommand;
            (d as FrameworkElement).MouseEnter += (x, y) => { command.Execute(d); };
        }

        

        #endregion

        #region Private Services

        private static void OnColorRGBChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var controlInstance = (CustomColorPicker)d;
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

    }
}
