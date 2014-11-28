using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLINQ
{
    public class SampleLINQManager
    {
        public void StartSample()
        {
            //Sample1();
            //Sample2();
            //Sample3();
            Sample4();
        }

        private void Sample1()
        {
            int a = 7;
            a.DisplayAssembly1();
        }

        class ProductInfo
        {
            public string Number { get; set; }
            public string Name { get; set; }
        }

        private void Sample2()
        {
            List<String> container = new List<string>() { "Hello", "test" };
            var collection = from p in container where p.Contains("l") select p;
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        public void Sample3()
        {
            List<ProductInfo> container = new List<ProductInfo>() { new ProductInfo() { Name = "FirstName", Number = "10" }, new ProductInfo() { Name = "SecondName", Number = "20" } };

            var result = from p in container select new { p.Name };
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void Sample4()
        {
            List<String> container = new List<string>() { "Hello", "1Hell o", "2Dea n" };

            //1//container = container.Where(x => x.Contains(" ")).OrderByDescending(x => x).Select(x => x.Substring(0, 3)).ToList<String>();
            //2//container = container.Where(delegate(string x) { return x.Contains(" "); }).OrderByDescending((string x) => { return x; }).Select(delegate(string x) { return x.Substring(0, 3); }).ToList<string>();
            //3//Func<string, bool> FilterMethod = new Func<string, bool>((string item) => { return item.Contains(" "); });
            //3//container = container.Where(FilterMethod).OrderByDescending((string x) => { return x; }).Select(x => x.Substring(0, 3)).ToList<string>();

            container.ForEach(x => Console.WriteLine(x));
            // result is : 2De, 1He
        }

    }
    static class ExtensionMethodClass
    {
        public static void DisplayAssembly1(this object obj)
        {
            Console.WriteLine("Its work anywhere!");
        }
    }
}
