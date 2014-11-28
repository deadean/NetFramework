using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            A t1 = new A();
            t1.MyProperty = 2;

            Console.ReadLine();
        }

        class A : Freezable
        {


            public int MyProperty
            {
                get { return (int)GetValue(MyPropertyProperty); }
                set { SetValue(MyPropertyProperty, value); }
            }

            // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty MyPropertyProperty =
                DependencyProperty.Register("MyProperty", typeof(int), typeof(A), new PropertyMetadata(0));

            public string Test { get; set; }

            protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
            {
                base.OnPropertyChanged(e);
            }
            protected override Freezable CreateInstanceCore()
            {
                return new A();
            }
        }
    }
}
