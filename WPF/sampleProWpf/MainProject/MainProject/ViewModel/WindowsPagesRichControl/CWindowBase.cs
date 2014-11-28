using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModelLib.Types;

namespace MainProject.ViewModel.WindowsPagesRichControl
{
    public class CWindowBase:Window
    {
        public CWindowBase()
        {
            this.DataContextChanged += CWindowBase_DataContextChanged;
            this.DataContext = new CWindowBaseVm();
        }

        protected virtual void CWindowBase_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((IViewModelBase)e.NewValue).ControlInstance = this;
        }

    }


}
