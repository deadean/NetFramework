using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdvancedLanguage
{
    

    public class AdvancedLanguageManager
    {
        public void StartSample()
        {
            //Sample1();
            //Sample2();

            //Thread th = new Thread(Sample3);
            //th.Start();
            //th.Join();

            //Console.WriteLine("Stop Thread");

            //Sample4();

            //Sample5();
            //Sample6();
        }

        class MyFreezableObject : System.Windows.Freezable 
        {
            private string mvState;
            public string State { get { return mvState; } set { mvState = IsFrozen ? mvState : value; } }
            protected override System.Windows.Freezable CreateInstanceCore()
            {
                return base.CreateInstance();
            }
        }
        private void Sample6()
        {
            MyFreezableObject object1 = new MyFreezableObject();
            object1.State = "a";
            object1.Freeze();

            object1.State = "b";
            Console.WriteLine(object1.State);
        }


        [Conditional("DEBUG")]
        private void Sample5()
        {
            Console.WriteLine("Hello");
        }

        public void WriteParams(int a, string c)
        {
            Console.WriteLine("a={0}, c={1}", a, c);
        }

        private void Sample4()
        {
            Lazy<TestLazyInitialization> llazy = new Lazy<TestLazyInitialization>();
            List<TestInitialization> list = new List<TestInitialization>();
        }

        class TestLazyInitialization{
            TestLazyInitialization() { Console.WriteLine("Lazy Constructor"); }
            
        }

        class TestInitialization
        {
            TestInitialization() { Console.WriteLine("Constructor"); }

        }

        private void Sample3()
        {
            FinalizerScope();
            Console.WriteLine("Function off end.");
        }

        private void FinalizerScope()
        {
            TestFinalizer tf = new TestFinalizer();
            Thread.Sleep(1000);
            GC.SuppressFinalize(tf);
        }
        class TestFinalizer
        {
            public TestFinalizer() { Console.WriteLine("Finalizer`s constructor."); }
            ~TestFinalizer()
            {
                Console.WriteLine("Finalizer`s cause.");
            }
        }

        public void Sample2()
        {
            Console.WriteLine("GC.GetTotalMemory(false) :"+GC.GetTotalMemory(false));

            AdvancedLanguageManager m = new AdvancedLanguageManager();
            Console.WriteLine("GC.GetGeneration(this) :" + GC.GetGeneration(m));
        }

        public void Sample1()
        {
            string s = "Hello";
            unsafe
            {
                fixed (char* c = s)
                {
                    c[0] = 'D';
                }
            }
            Console.WriteLine(s);
            Console.WriteLine("Hello");
        }
    }
}
