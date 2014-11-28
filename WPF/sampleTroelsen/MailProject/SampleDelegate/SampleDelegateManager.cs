using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleDelegate
{
    public class SampleDelegateManager
    {
        public void StartSample()
        {
            //Sample1();
            //Sample2();
            //Sample3();
            //Sample4();
            Sample5();
        }

        public delegate int SumDelegate(int a, int b);
        private void Sample1()
        {
            SumDelegate sumDelegate = new SumDelegate(this.SumMethod);
            foreach (var item in sumDelegate.GetInvocationList())
            {
                Console.WriteLine(item.Method.ToString());
                Console.WriteLine(item.Target);
            }
        }
        private int SumMethod(int num1, int num2)
        {
            return num1 + num2;
        }

        public delegate T GenericDelegate<T> (T value1, T value2);
        private string TestGenericDelegate(string a, string b)
        {
            Console.WriteLine("First invocation method");
            return a+b;
        }
        private string TestGenericDelegate2(string a, string b)
        {
            Console.WriteLine("Second invocation method");
            return String.Empty;
        }
        private void Sample2()
        {
            GenericDelegate<String> genericDelegate = new GenericDelegate<String>(TestGenericDelegate);
            genericDelegate = GenericDelegate<String>.Combine(genericDelegate, new GenericDelegate<String>(this.TestGenericDelegate2)) as GenericDelegate<String>;

            Console.WriteLine(genericDelegate("Hello", "Dean"));
        }

        private void DisplayMessage(string message, ConsoleColor consoleColor)
        {
            ConsoleColor stateConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;

            Console.WriteLine(message);

            Console.ForegroundColor = stateConsoleColor;
        }
        private void Sample3()
        {
            Action<string, ConsoleColor> actionDisplayMessage = new Action<string, ConsoleColor>(DisplayMessage);
            actionDisplayMessage("Hello", ConsoleColor.Green);
        }

        private void Sample4()
        {
            Func<int, int, int> funcSumDelegate = new Func<int, int, int>(this.SumMethod);
            Console.WriteLine(funcSumDelegate.Invoke(4, 8));
        }

        private void Sample5()
        {
            Bird bird = new Bird();
            int localVariable = 0;
            //bird.SingEventBird += delegate(int n)
            // Already we can use this code enstead of defining new unnamed method
            //bird.SingEventBird += n => 
            //bird.SingEventBird += (n) => 
            bird.SingEventBird += (int n) => 
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Bird Sing Songs!");
                }
                localVariable++;
            };

            bird.BirdLife();
            Console.WriteLine("Result of local variable which have been used in the unnamed method is :{0}",localVariable);
        }
        class Bird
        {
            public delegate void SingingEvent(int number);
            public event SingingEvent SingEventBird;

            public void BirdLife()
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("I am free");
                    if (i % 2 == 0 && SingEventBird != null)
                    {
                        SingEventBird(i);
                    }
                }
            }
        }
    }
}
