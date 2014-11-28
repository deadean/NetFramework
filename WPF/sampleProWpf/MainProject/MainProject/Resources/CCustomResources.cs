using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MainProject.Resources
{
    public class CCustomResources
    {
        public static ComponentResourceKey SadTileBrushKey
        {
            get
            {
                return new ComponentResourceKey(
                typeof(CCustomResources), "SadTileBrush");
            }
        }

        public static string Text
        {
            get
            {
                return "ddd";
            }
        }

        public static DependencyObject Object
        {
            get;
            set;
        }

        public static string GetParent(DependencyObject text)
        {
            var res = System.Windows.LogicalTreeHelper.GetParent(Object);
            return res == null ? "Not Found" : res.ToString();
        }
    }
}
