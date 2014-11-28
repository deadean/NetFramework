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
    public class CProductDataTemplateSelector:DataTemplateSelector
    {
        public DataTemplate DefaultTemplate
        {
            get;
            set;
        }
        public DataTemplate HighlightTemplate
        {
            get;
            set;
        }
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            Product product = item as Product;
            if (product == null)
                return DefaultTemplate;

            if (product.Category.Name.Contains("Category 1"))
                return HighlightTemplate;

            return DefaultTemplate;
        }
    }
}
