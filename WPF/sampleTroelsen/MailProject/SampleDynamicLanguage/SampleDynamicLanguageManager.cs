using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace SampleDynamicLanguage
{
    public class SampleDynamicLanguageManager
    {
        public void StartSample()
        {
            //Sample1();
            Sample2();
        }

        // We can simply use Reflection in the work with Assembly dll`s.
        private void Sample2()
        {
            string reflectionType = "AdvancedLanguage.AdvancedLanguageManager, AdvancedLanguage";
            ObjectHandle classInstanceHandle = Activator.CreateInstance("AdvancedLanguage", Type.GetType(reflectionType).FullName);
            dynamic classInstance = classInstanceHandle.Unwrap();
            classInstance.WriteParams(2, "Hello");
        }

        private void Sample1()
        {
            dynamic dynoStr = "hello";
            Console.WriteLine(dynoStr.ToUpper()); 
        }
    }
}
