using EssentialTools.Models;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EssentialTools.Infrastructure
{
	public class NinjectDependencyResolver:IDependencyResolver
	{
		private IKernel modKernel;

		public NinjectDependencyResolver(IKernel kernel)
		{
			modKernel = kernel;
			AddBindings();
		}

		private void AddBindings()
		{
			modKernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InRequestScope();
			modKernel.Bind<IDiscountHelper>().To<DiscountHelper>().WithPropertyValue("DiscountSize", 50M);
			modKernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqValueCalculator>();
		}

		public object GetService(Type serviceType)
		{
			return modKernel.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return modKernel.GetAll(serviceType);
		}
	}
}
