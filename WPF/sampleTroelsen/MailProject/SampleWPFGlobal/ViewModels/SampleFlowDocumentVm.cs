using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels
{
    public class SampleFlowDocumentVm:ViewModelBase
    {
        public SampleFlowDocumentVm()
        {
            Text = "Here are some fun facts about the WPF Documents API!";
        }
        public string Text
        {
            get;
            set;
        }
    }
}
