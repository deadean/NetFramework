using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessesAppDomainsObjectContext
{
    public class ProcessesAppDomainsObjectContextManager
    {
        public void StartSample()
        {
            //Sample1();
            //Sample2();
            //Sample3();
            //Sample4();
            //Sample5();
            //Sample6();
            Sample7();
        }

        private void Sample7()
        {
            Console.WriteLine("***** Fun with Custom AppDomains *****\n");
            // Show all loaded assemblies in default AppDomain.
            AppDomain defaultAD = AppDomain.CurrentDomain;
            ListAllAssembliesInAppDomain(defaultAD);

            // Make a new AppDomain.
            MakeNewAppDomain();
            Console.ReadLine();

        }

        private void MakeNewAppDomain()
        {
            // Make a new AppDomain in the current process and
            // list loaded assemblies.
            AppDomain newAD = AppDomain.CreateDomain("SecondAppDomain");
            ListAllAssembliesInAppDomain(newAD);
        }
        private void ListAllAssembliesInAppDomain(AppDomain ad)
        {
            // Now get all loaded assemblies in the default AppDomain.
            var loadedAssemblies = from a in ad.GetAssemblies()
                                   orderby a.GetName().Name
                                   select a;
            Console.WriteLine("***** Here are the assemblies loaded in {0} *****\n",
            ad.FriendlyName);
            foreach (var a in loadedAssemblies)
            {
                Console.WriteLine("-> Name: {0}", a.GetName().Name);
                Console.WriteLine("-> Version: {0}\n", a.GetName().Version);
            }
        }

        private void Sample6()
        {
            DisplayDADStats();
        }

        private void DisplayDADStats()
        {
            // Get access to the AppDomain for the current thread.
            AppDomain defaultAD = AppDomain.CurrentDomain;
            // Print out various stats about this domain.
            Console.WriteLine("Name of this domain: {0}", defaultAD.FriendlyName);
            Console.WriteLine("ID of domain in this process: {0}", defaultAD.Id);
            Console.WriteLine("Is this the default domain?: {0}",
            defaultAD.IsDefaultAppDomain());
            Console.WriteLine("Base directory of this domain: {0}", defaultAD.BaseDirectory);
        }

        private void Sample5()
        {
            // Dont forget about ProccessStartInfo struct to start Process Normally.
            StartAndKillProcess();
        }

        static void StartAndKillProcess()
        {
            Process ieProc = null;
            // Launch Internet Explorer, and go to facebook!
            try
            {
                ieProc = Process.Start("chrome.exe", "www.livescore.com");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Write("--> Hit enter to kill {0}...", ieProc.ProcessName);
            Console.ReadLine();
            // Kill the iexplore.exe process.
            try
            {
                ieProc.Kill();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Sample4()
        {
            ListAllRunningProcesses();
            int PID = Convert.ToInt32(Console.ReadLine());
            EnumModsForPid(PID);
        }

        static void EnumModsForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Console.WriteLine("Here are the loaded modules for: {0}",
            theProc.ProcessName);
            ProcessModuleCollection theMods = theProc.Modules;
            foreach (ProcessModule pm in theMods)
            {
                string info = string.Format("-> Mod Name: {0}", pm.ModuleName);
                Console.WriteLine(info);
            }
            Console.WriteLine("************************************\n");
        }

        private void Sample3()
        {
            Process runningProc = Process.GetProcesses(".").FirstOrDefault(x => x.ProcessName == "MailProject");
            EnumThreadsForPid(runningProc.Id);
        }

        static void EnumThreadsForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            // List out stats for each thread in the specified process.
            Console.WriteLine("Here are the threads used by: {0}",
            theProc.ProcessName);
            ProcessThreadCollection theThreads = theProc.Threads;
            foreach (ProcessThread pt in theThreads)
            {
                string info =
                string.Format("-> Thread ID: {0}\tStart Time: {1}\tPriority: {2}",
                pt.Id, pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
                Console.WriteLine(info);
            }
            Console.WriteLine("************************************\n");
        }

        private void Sample2()
        {
            ListofAllRunningProcesses();
        }

        private void Sample1()
        {
            ListAllRunningProcesses();
        }

        static void ListAllRunningProcesses()
        {
            // Get all the processes on the local machine, ordered by
            // PID.
            var runningProcs =
            from proc in Process.GetProcesses(".") orderby proc.Id select proc;
            // Print out PID and name of each process.
            foreach (var p in runningProcs)
            {
                string info = string.Format("-> PID: {0}\tName: {1}",
                p.Id, p.ProcessName);
                Console.WriteLine(info);
            }
            Console.WriteLine("************************************\n");
        }

        static void ListofAllRunningProcesses()
        {
            for (int i = 0; i < 100000; i++)
            {
                Process p = GetSpecificProcess(i);
                if (p == null)
                    continue;
                string info = string.Format("-> PID: {0}\tName: {1}",p.Id, p.ProcessName);
                Console.WriteLine(info);
            }
            Console.WriteLine("************************************\n");
        }
        static Process GetSpecificProcess(int PID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(PID);
            }
            catch (ArgumentException ex)
            {
                //Console.WriteLine(ex.Message);
            }
            return theProc;
        }
    }
}
 