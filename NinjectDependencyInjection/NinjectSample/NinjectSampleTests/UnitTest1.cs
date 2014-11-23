using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using NinjectSample;

namespace NinjectSampleTests
{
	[TestClass]
	public class UnitTest1
	{
		IKernel ninjectKernel;
		public UnitTest1()
		{
			ninjectKernel = new StandardKernel(new NinjectSample.NinjectConfigurator());
		}

		[TestMethod]
		public void TestMethod1()
		{
			var car = ninjectKernel.Get<ICar>();
			Assert.IsNotNull(car);
		}

		[TestMethod]
		public void TestMethod2()
		{
			var car = ninjectKernel.Get<ICar>();

			Assert.IsTrue(car.Start());
		}
	}
}
