using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication;

using Timer = System.Threading.Timer;

namespace SampleMultithreadedParallelAsync
{
    public class MultithreadedParallelAsyncManager
    {

        private delegate int AddDelegate(int a, int b);
        private static bool isDone = false;
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        private object lockObject = new object();
        public void StartSample()
        {
            //Sample1();
            //Sample2();
            //Sample3();
            //Sample4();
            //Sample5();
            //Sample6();
            //Sample7();
            //Sample8();
            //Sample9();
            //Sample10();
            //Sample11();
            //Sample12();
            //Sample13();
            //Sample14();
            Sample15();
        }

        private void Sample15()
        {
            Parallel.For(0, 100, x => Console.WriteLine(DateTime.Now));
        }

        private void Sample14()
        {
            int min = 100000, count = 1000000;
            DateTime startTime = DateTime.Now;
            var result = GetPrimeCount(min, count);
            Console.WriteLine(string.Format("It took {0} milliseconds to finish the sync call, returned {1}", DateTime.Now.Subtract(startTime).Milliseconds, result));


            startTime = DateTime.Now;
            var result1 = GetPrimeCountAsync(min, count);
            Console.WriteLine(string.Format("It took {0} milliseconds to finish the async call, returned {1}", DateTime.Now.Subtract(startTime).Milliseconds, result1.Result));

            Console.ReadLine();
        }

        public async Task<int> GetPrimeCountAsync(int min, int count)
        {
            return await Task.Run<int>(() =>
            {
                PrintCurrentThreadId("GetPrimeCount");
                return ParallelEnumerable.Range(min, count).Count(n =>
                    Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i =>
                    n % i > 0));
            });
        }

        private void Sample13()
        {
            int min = 100000, count = 1000000;
            DateTime startTime = DateTime.Now;
            int result = GetPrimeCount(min, count);
            Console.WriteLine(string.Format("It took {0} milliseconds to finish the sync call, returned {1}", DateTime.Now.Subtract(startTime).Milliseconds, result));

            Console.WriteLine("Step 2");
            startTime = DateTime.Now;
            var asyncResult = BeginGetPrimeCount(min, count, null, null);
            //Do some work here 
            result = EndGetPrimeCount(asyncResult);
            Console.WriteLine(string.Format("It took {0} milliseconds to finish the async call, returned {1}", DateTime.Now.Subtract(startTime).Milliseconds, result));

            Console.WriteLine("Step 3");
            startTime = DateTime.Now;
            //Or call it this way (not benefiting from threading time)

            result = EndGetPrimeCount(BeginGetPrimeCount(min, count, null, null));
            Console.WriteLine(string.Format("It took {0} milliseconds to finish the async call, returned {1}", DateTime.Now.Subtract(startTime).Milliseconds, result));

            Console.ReadLine();
        }

        private delegate int GetPrimeCountHandler(int min, int count);
        private GetPrimeCountHandler getPrimeCountCaller;  

        public IAsyncResult BeginGetPrimeCount(int min,
          int count, AsyncCallback callback, object userState)
        {
            getPrimeCountCaller = this.GetPrimeCount;
            PrintCurrentThreadId("BeginGetPrimeCount");
            return getPrimeCountCaller.BeginInvoke(min, count, callback, userState);
        }
        public int EndGetPrimeCount(IAsyncResult result)
        {
            PrintCurrentThreadId("EndGetPrimeCount");

            return getPrimeCountCaller.EndInvoke(result);
        }

        public int GetPrimeCount(int min, int count)
        {
            PrintCurrentThreadId("GetPrimeCount");
            return ParallelEnumerable.Range(min, count).Count(n =>
                Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i =>
                n % i > 0));
        }

        public static void PrintCurrentThreadId(string methodName)
        {
            Console.WriteLine(string.Format("{0} is in thread id:{1}", methodName, Thread.CurrentThread.ManagedThreadId));
        }


        private void Sample12()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form3()); 
        }

        private void Sample11()
        {
            Task.Factory.StartNew(() =>
            {
                ProcessIntData();
            });
            waitHandle.WaitOne();
        }

        private void ProcessIntData()
        {
            // Get a very large array of integers.
            int[] source = Enumerable.Range(1, 10000000).ToArray();
            // Find the numbers where num % 3 == 0 is true, returned
            // in descending order.

            //int[] modThreeIsZero = (from num in source
            //                        where num % 3 == 0
            //                        orderby num descending
            //                        select num).ToArray();

            int[] modThreeIsZero = (from num in source.AsParallel()//.WithCancellation()
                                    where num % 3 == 0
                                    orderby num descending
                                    select num).ToArray();



            MessageBox.Show(string.Format("Found {0} numbers that match query!",
            modThreeIsZero.Count()));
            waitHandle.Set();
        }

        private void Sample10()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form2()); 
        }

        private void Sample9()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1()); 
        }

        private void Sample8()
        {
            WaitCallback wc = new WaitCallback(PrintText);
            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(wc, "Hello");    
            }
            waitHandle.WaitOne();
        }

        private void PrintText(object state)
        {
            Console.WriteLine(state as string);
            waitHandle.Set();
        }

        private void Sample7()
        {
            //TimerCallback timerCallBack = new TimerCallback(delegate(object context) { Console.WriteLine("Time is {0}", DateTime.Now); });
            TimerCallback timerCallBack = new TimerCallback(PrintTime);
            Timer t = new Timer(timerCallBack, null, 0, 100);
        }

        private void PrintTime(object context)
        {
            Console.WriteLine("Time is ");
        }

        private void Sample6()
        {
            List<Thread> lth = new List<Thread>();
            for (int i = 0; i < 5; i++)
            {
                lth.Add(new Thread(PrintNumbers));
            }
            lth.ForEach(x => x.Start());
        }
        private void PrintNumbers()
        {
            lock (lockObject)
            {
                Console.Write("Start :");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(i + " ");
                }
                Console.Write(" End\n");
            }
        }

        private void Sample5()
        {
            Thread th = new Thread(LongWork);
            th.IsBackground = true;
            th.Start();
        }

        // run two start!!!
        private void LongWork(object obj)
        {
            for (int i = 0; i < 10000000; i++)
            {
                Console.WriteLine("long work");
            }   
        }

        private void Sample4()
        {
            Thread th = new Thread(new ParameterizedThreadStart(Sum));
            th.Start(5);
            waitHandle.WaitOne();
        }

        private static void Sum(object st)
        {
            int a = (int)st;
            Console.WriteLine("A={0}",a);
            waitHandle.Set();
        }


        private void Sample3()
        {
            Thread th = new Thread(new ThreadStart(PrintText));
            th.Start();
            Console.WriteLine("STOP");
        }

        private void PrintText() 
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Hello");
            }
        }

        private void Sample2()
        {
            AddDelegate method = new AddDelegate(this.AddMethod2);
            IAsyncResult result = method.BeginInvoke(10, 20, new AsyncCallback(this.AsyncConplete), null);

            while (!isDone)
            {
                Console.WriteLine("Main doing work!");
            }
        }

        private int AddMethod2(int a, int b)
        {
            GetCurrentThreadID();
            int d = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                d++;
            }
            Console.WriteLine("Result is " + (a + b));
            return a + b;
        }

        private void AsyncConplete(IAsyncResult result)
        {
            GetCurrentThreadID();
            Console.WriteLine("Add operation completed");
            isDone = true;
        }

        private void Sample1()
        {
            GetCurrentThreadID();

            AddDelegate method = new AddDelegate(this.AddMethod);
            IAsyncResult result = method.BeginInvoke(10, 20, null, null);

            Console.WriteLine("Doing something");
            Thread.Sleep(2000);

            int resultAdd = method.EndInvoke(result);
            Console.WriteLine("Method add invoked normally");
        }

        private int AddMethod(int a, int b)  
        {
            GetCurrentThreadID();
            int d = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                d++;
            }
            Console.WriteLine("Result is " + (a + b));
            return a + b;
        }

        private static void GetCurrentThreadID()
        {
            Console.WriteLine("Current Thread ID :" + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
 