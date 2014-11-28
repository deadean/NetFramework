using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MainProject.View.Data
{
    public class CProductStyleSelector : StyleSelector
    {
        public Style DefaultStyle
        {
            get;
            set;
        }
        public Style HighlightStyle
        {
            get;
            set;
        }
        public override Style SelectStyle(object item, DependencyObject container)
        {
            Product product = item as Product;
            if (product == null)
                return new Style();

            if (product.Category.Name.Contains("Category 1"))
                return HighlightStyle;

            return DefaultStyle;
        }
    }
}
