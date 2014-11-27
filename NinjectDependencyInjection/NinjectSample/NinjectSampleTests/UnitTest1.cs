using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using NinjectSample;
using NinjectService;
using System.Threading.Tasks;
using System.Linq;

namespace NinjectSampleTests
{
	[TestClass]
	public class UnitTest1
	{
		static INinjectService service = new NinjectService.NinjectService();

		static UnitTest1()
		{
			service.Register<ICar, Car>();
			service.Register<IEngine, Engine>();
		}

		[TestMethod]
		public void TestMethod1()
		{
			var car = service.Get<ICar>();
			Assert.IsNotNull(car);
		}

		[TestMethod]
		public void TestMethod2()
		{
			var car = service.Get<ICar>();

			Assert.IsTrue(car.Start());
		}

		[TestMethod]
		public void TestMethod3()
		{
			service.Register<ICar, Car2>();

			var cars = service.GetAll<ICar>();
			var res = true;

			Parallel.ForEach(cars, car => res&= car.Start());

			Assert.IsFalse(res);
			
		}
	}
}
