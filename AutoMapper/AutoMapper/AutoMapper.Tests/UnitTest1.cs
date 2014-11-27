using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper.AutoMapper;
using AutoMapper.Data;

namespace AutoMapper.Tests
{
	[TestClass]
	public class UnitTest1
	{
		private static IAutoMapper autoMapper = new AutoMapper.AutoMapper();

		static UnitTest1()
		{
			autoMapper.Register<Car, CarNew>()
				.ForMember(opt => opt.FirstLine, x => x.MapFrom(t => t.Name));
		}

		[TestMethod]
		public void TestMethod1()
		{
			var car = new Car() { Name = "sss" };
			CarNew carNew = autoMapper.Map<CarNew>(car);

			Assert.IsNotNull(carNew);
			Assert.AreEqual(car.Name, carNew.FirstLine);
		}
	}
}
