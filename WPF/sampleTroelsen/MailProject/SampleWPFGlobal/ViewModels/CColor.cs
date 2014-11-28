using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Ink;
using ViewModelLib.Types;

namespace SampleWPFGlobal.ViewModels
{
    public class CColor:DrawingAttributes
    {
        public CColor():base()
        {
            HeightProp = 20;
        }
        public string Name { get; set; }
        public int HeightProp { get; set; }
    }
}
