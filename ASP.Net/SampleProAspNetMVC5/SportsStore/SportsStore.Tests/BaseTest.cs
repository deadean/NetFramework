using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Tests
{
	[TestClass]
	public abstract class BaseTest
	{
		protected readonly Mock<IProductRepository> mock;
		protected readonly Mock<IOrderProcessor> mockOrderProcessor;

		protected BaseTest()
		{
			mock = new Mock<IProductRepository>();

			mock.Setup(m => m.Products).Returns(
				new Product[]
				{
					new Product { ProductID=1, Name="Product1", Category = "Cat1", Price = 100M},
					new Product { ProductID=2, Name="Product2", Category = "Cat2", Price = 50M},
					new Product { ProductID=3, Name="Product3", Category = "Cat1", Price = 100M},
					new Product { ProductID=4, Name="Product4", Category = "Cat2", Price = 25M},
					new Product { ProductID=5, Name="Product5", Category = "Cat3", Price = 300M}
				}
			);

			mockOrderProcessor = new Mock<IOrderProcessor>();
    }
	}
}
