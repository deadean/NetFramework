using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SportsStore.WebUI.Infrastructure
{
	public class NinjectDependencyResolver : IDependencyResolver
	{
		private IKernel modKernel;

		public NinjectDependencyResolver(IKernel kernel)
		{
			modKernel = kernel;
			AddBindings();
		}

		private void AddBindings()
		{
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
