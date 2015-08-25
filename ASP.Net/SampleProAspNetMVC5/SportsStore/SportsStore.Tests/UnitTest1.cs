using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Collections.Generic;

namespace SportsStore.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(
				new Product[]
				{
					new Product { ProductID=1, Name="Product1"},
					new Product { ProductID=2, Name="Product2"},
					new Product { ProductID=3, Name="Product3"},
					new Product { ProductID=4, Name="Product4"},
					new Product { ProductID=5, Name="Product5"}
				}
			);

			ProductController controller = new ProductController(mock.Object);
			controller.PageSize = 3;

			IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2).Model;
			Product[] prodArray = result.ToArray();

			Assert.IsTrue(prodArray.Length == 2);
			Assert.AreEqual(prodArray[0].Name, "Product4");
			Assert.AreEqual(prodArray[1].Name, "Product5");
		}
	}
}
