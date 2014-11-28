using SampleDelegate;
using SampleLINQ;
//using AdvancedLanguage;
using SampleAssemblyManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleLINQToXML;
using SampleTypeReflectionLateBinding;
using SampleDynamicLanguage;
using AdvancedLanguage;
using ProcessesAppDomainsObjectContext;
using SampleMultithreadedParallelAsync;
using ADO.NET.Part1;
using ADO.NET.Part2;
using SampleEntityFrameWork;
using SampleWCF;
using System.Threading;
using System.Windows;
using SampleMonadsManager;

namespace MailProject
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //SampleDelegateManager sampleManager = new SampleDelegateManager();
            //sampleManager.StartSample();

            //SampleLINQManager sampleLINQ = new SampleLINQManager();
            //sampleLINQ.StartSample();

            //AdvancedLanguageManager sampleAdvancedLanguage = new AdvancedLanguageManager();
            //sampleAdvancedLanguage.StartSample();

            //SampleAsemblyManager sampleAssemblyManager = new SampleAsemblyManager();
            //sampleAssemblyManager.StartSample();

            //SampleTypeReflectionLateBinding_ sampleManager = new SampleTypeReflectionLateBinding_();
            //sampleManager.StartSample();

            //SampleDynamicLanguageManager sampleManager = new SampleDynamicLanguageManager();
            //sampleManager.StartSample();

            //ProcessesAppDomainsObjectContextManager sampleManager = new ProcessesAppDomainsObjectContextManager();
            //sampleManager.StartSample();

            MultithreadedParallelAsyncManager sampleManager = new MultithreadedParallelAsyncManager();
            sampleManager.StartSample();

            //ADOConnectedLayaerManager sampleManager = new ADOConnectedLayaerManager();
            //sampleManager.StartSample();

            //AdoNetDisconnectedLayerManager sampleManager = new AdoNetDisconnectedLayerManager();
            //sampleManager.StartSample();

            //SampleEntityFrameWorkManager sampleManager = new SampleEntityFrameWorkManager();
            //sampleManager.StartSample();

            //SampleLINQToXMLManager sampleLinqtoXmlManager = new SampleLINQToXMLManager();
            //sampleLinqtoXmlManager.StartSample();
            
            //SampleWCFManager sampleWcfManager = new SampleWCFManager();
            //sampleWcfManager.StartSample();

            //SampleMonads sampleMonadManager = new SampleMonads();
            //sampleMonadManager.StartSample();

            //Thread t = new Thread(() =>
            //{
            //    Application app = new Application();
            //    app.Run(new SampleWPFGlobal.MainWindow());
            //});
            //t.SetApartmentState(ApartmentState.STA);
            //t.Start();

            Console.WriteLine("=======================Stop Main method.");
        }
    }
}
