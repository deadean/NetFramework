using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace SampleTypeReflectionLateBinding
{
    public sealed class MyDescriptionAttribute : System.Attribute
    {
        public string Description { get; set; }
        public MyDescriptionAttribute(string message) { Description = message; }
        public MyDescriptionAttribute() { }
    }

    [MyDescription(Description = "hello")]
    public class SampleTypeReflectionLateBinding_
    {
        private const string asmName = "AdvancedLanguage";
        public void StartSample()
        {
            //Sample1();
            //Sample2();
            //Sample3();
            //Sample4();
            //Sample5();

        }

        private void Sample5()
        {
            foreach (var item in this.GetType().GetCustomAttributes())
            {
                if(item is MyDescriptionAttribute)
                    Console.WriteLine(((MyDescriptionAttribute)item).Description);
            }
            
        }

        private void Sample4()
        {
            Assembly assembly = null;
            assembly = Assembly.Load(asmName);

            if (assembly != null)
            {
                DisplayTypesInAsm(assembly);
                CreateUsingLateBinding(assembly);
            }
        }

        private void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                string reflectionType = "AdvancedLanguage.AdvancedLanguageManager, AdvancedLanguage";
                Type t = Type.GetType(reflectionType);

                ObjectHandle classInstanceHandle = Activator.CreateInstance("AdvancedLanguage", t.FullName);
                object classInstance = classInstanceHandle.Unwrap();
                t = classInstance.GetType();

                ListMethods(t);
                MethodInfo method = t.GetMethod("WriteParams");
                method.Invoke(classInstance, new object[] { 2, "Hello" });
                t.GetMethod("Sample1").Invoke(classInstance,null);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Assembly must were been in the same diractory of the runable file
        private void Sample3()
        {
            DisplayTypesInAsm(Assembly.Load(asmName));
        }

        private void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("\n***** Types in Assembly *****");
            Console.WriteLine("->{0}", asm.FullName);
            Type[] types = asm.GetTypes();
            foreach (Type t in types)
                Console.WriteLine("Type: {0}", t);
            Console.WriteLine("");
        }

        // Sample to InvokeMethod FROM OTHER Assembly
        private void Sample2()
        {
            string reflectionType = "AdvancedLanguage.AdvancedLanguageManager, AdvancedLanguage";
            Type t = Type.GetType(reflectionType);

            // first, create a handle instead of the actual object
            ObjectHandle classInstanceHandle = Activator.CreateInstance("AdvancedLanguage", t.FullName);
            // unwrap the real slim-shady
            object classInstance = classInstanceHandle.Unwrap(); 
            // re-map the type to that of the object we retrieved
            t = classInstance.GetType();

            t.GetMethod("Sample1").Invoke(classInstance, null);
        }

        private void Sample1()
        {
            string reflectionType = "AdvancedLanguage.AdvancedLanguageManager, AdvancedLanguage";
            Type t = Type.GetType(reflectionType);
            ListMethods(t);
            ListInterfaces(t);
        }

        // Display method names of type.
        static void ListMethods(Type t)
        {
            Console.WriteLine("***** Methods *****");
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
                Console.WriteLine("->{0}", m.Name);
            Console.WriteLine();
        }

        // Display implemented interfaces.
        static void ListInterfaces(Type t)
        {
            Console.WriteLine("***** Interfaces *****");
            var ifaces = from i in t.GetInterfaces() select i;
            foreach (Type i in ifaces)
                Console.WriteLine("->{0}", i.Name);
        }

    }
}
