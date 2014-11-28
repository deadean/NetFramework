using MainProject.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewModelLib.Commands;
using ViewModelLib.Types;

namespace MainProject.ViewModel
{
    public class CSample4Vm:ViewModelBase
    {
        private List<Window> mvListWindows = new List<Window>();
        public List<Window> ListWindows
        {
            get { return mvListWindows; }
            set { mvListWindows = value; }
        }

        #region Commands

        public ICommand CreateWindow
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {
                    var owner = x as Window;
                    if (owner == null)
                        return;

                    var wnd = new Window();
                    wnd.Owner = owner;
                    wnd.Show();
                    ListWindows.Add(wnd);
                });
            }
        }

        public ICommand RefreshWindows
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ListWindows.ForEach(x=>x.SetValue(Window.TitleProperty,"Updated in "+DateTime.Now.ToString()));
                });
            }
        }

        public ICommand ShowResourcesKey
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Assembly assembly = Assembly.GetAssembly(this.GetType());
                    string resourceName = assembly.GetName().Name + ".g";
                    ResourceManager rm = new ResourceManager(resourceName, assembly);
                    var str = String.Empty;
                    using (ResourceSet set = rm.GetResourceSet(CultureInfo.CurrentCulture, true, true))
                    {
                        foreach (DictionaryEntry res in set)
                        {
                            str+=res.Key.ToString()+System.Environment.NewLine;
                        }
                    }
                    MessageBox.Show(str);
                    
                });
            }
        }

        
        public ICommand StartNewApplication
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    // Create the application.
                    Application app = new Application();
                    // Create the main window.
                    Window1 win = new Window1();
                    // Launch the application and show the main window.
                    app.Run(win);
                });
            }
        }

        #endregion

        
    }
}
