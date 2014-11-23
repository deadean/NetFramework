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
		public override void Load()
		{
			this.Bind<IEngine>().To<Engine>();
			this.Bind<ICar>().To<Car>();
		}
	}
}
