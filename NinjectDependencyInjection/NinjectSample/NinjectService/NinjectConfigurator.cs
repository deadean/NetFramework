using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectSample
{
	public class NinjectConfigurator:NinjectModule
	{
		public void Register<TI, TR>() where TR:TI
		{
			this.Bind<TI>().To<TR>();
		}

		public override void Load()
		{
			
		}
	}
}
