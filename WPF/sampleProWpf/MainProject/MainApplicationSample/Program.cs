using MainProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MainApplicationSample
{
    class Program
    {
        [STAThread()]
        static void Main(string[] args)
        {
            try
            {
                Application app = new Application();
                MainWindow win = new MainWindow();
                app.ShutdownMode = ShutdownMode.OnMainWindowClose;
                app.Run(win);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }
    }
}
