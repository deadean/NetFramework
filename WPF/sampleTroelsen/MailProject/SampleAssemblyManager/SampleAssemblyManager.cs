using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAssemblyManager
{
    public class SampleAsemblyManager
    {   
        public void StartSample()
        {
            Sample1();
        }

        private void Sample1()
        {
            System.Reflection.Assembly assemblyClass1 = System.Reflection.Assembly.Load("SampleAssembly");
            object obj = assemblyClass1.CreateInstance("SampleAssembly.Class1");
        }
    }
}
