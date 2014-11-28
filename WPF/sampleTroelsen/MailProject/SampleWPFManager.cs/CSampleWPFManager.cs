using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SampleWPFManager
{
    public class CSampleWPFManager
    {
        public void StartSample()
        {
            Sample1();
        }

        [STAThread]
        private void Sample1()
        {
            Thread t = new Thread(() =>
            {
                Application app = new Application();
                app.Run(new UserCoontrol1);
            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

    }
}
