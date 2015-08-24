using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
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
			Mock<IProductRepository> mock = new Mock<IProductRepository>();

			mock.Setup(m => m.Products).Returns(new List<Product>
			{
				new Product { Name = "Football", Price = 25},
				new Product { Name = "Surf board", Price = 179},
				new Product { Name = "Running shoes", Price = 95}
			});

			//modKernel.Bind<IProductRepository>().ToConstant(mock.Object);
			modKernel.Bind<IProductRepository>().To<EFProductRepository>();
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
