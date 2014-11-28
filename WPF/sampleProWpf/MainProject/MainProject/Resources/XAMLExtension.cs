using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace MainProject.Resources
{
    [MarkupExtensionReturnType(typeof(string))]
    public class XAMLExtension : MarkupExtension
    {
        public XAMLExtension()
		{
		}

        public XAMLExtension(string objectIn)
		{
            ObjectIn = objectIn;
		}

        [ConstructorArgument("objectIn")]
		public string ObjectIn { get; set; }

		public string ClassType { get; set; }

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
            return "Hello";
		}
    }
}
