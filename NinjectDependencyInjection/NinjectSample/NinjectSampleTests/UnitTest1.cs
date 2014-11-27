using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using NinjectSample;
using NinjectService;

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
	}
}
