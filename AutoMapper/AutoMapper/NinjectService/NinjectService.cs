using Ninject;
using NinjectSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectService
{
	public class NinjectService:INinjectService
	{
		private static IKernel ninjectKernel;
		private static NinjectConfigurator configurator;

		static NinjectService()
		{
			configurator = new NinjectConfigurator();
			ninjectKernel = new StandardKernel(configurator);
		}

		public NinjectService() { }

		public void Register<TI, TR>() where TR : TI
		{
			configurator.Register<TI, TR>();
		}

		public T Get<T>()
		{
			return ninjectKernel.Get<T>();
		}
	}
}
