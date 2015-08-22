using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;
using Moq;

namespace EssentialTools.Tests
{
	[TestClass]
	public class UnitTest1
	{
		private Product[] modProduct =
		{
			new Product() { Name = "Kayak", Category = "WaterSports", Price = 275M },
			new Product() { Name = "LifeJacket", Category = "WaterSports", Price = 48.9M },
			new Product() { Name = "Soccer ball", Category = "Soccer", Price = 19.50M },
			new Product() { Name = "Corner flag", Category = "Soccer", Price = 34.95M },
		};

		private IDiscountHelper GetTestObject()
		{
			return new MinimumDiscountHelper();
		}

		[TestMethod]
		public void TestMethod1()
		{
			IDiscountHelper target = GetTestObject();
			decimal total = 200;

			var discountTotal = target.ApplyDiscount(total);

			Assert.AreEqual(total * 0.9M, discountTotal);
		}

		[TestMethod]
		public void TestMethod2()
		{
			IDiscountHelper target = GetTestObject();

			var tenDiscountTotal = target.ApplyDiscount(10);
			var HundredDiscountTotal = target.ApplyDiscount(100);
			var FiftyDiscountTotal = target.ApplyDiscount(50);

			Assert.AreEqual(5, tenDiscountTotal, "$10 discount is wrong");
			Assert.AreEqual(95, HundredDiscountTotal, "$100 discount is wrong");
			Assert.AreEqual(45, FiftyDiscountTotal, "$50 discount is wrong");
		}

		[TestMethod]
		public void TestMethod3()
		{
			IDiscountHelper target = GetTestObject();

			var discount5 = target.ApplyDiscount(5);
			var discount0 = target.ApplyDiscount(0);

			Assert.AreEqual(5, discount5);
			Assert.AreEqual(0, discount0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestMethod4()
		{
			IDiscountHelper target = GetTestObject();
			target.ApplyDiscount(-1);
		}

		[TestMethod]
		public void TestMethod5()
		{
			Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
			mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
				.Returns<decimal>(total => total);

			var target = new LinqValueCalculator(mock.Object);

			var result = target.ValueProducts(modProduct);

			Assert.AreEqual(modProduct.Sum(x => x.Price), result);
		}

		private Product[] CreateProduc(decimal value)
		{
			return new[] { new Product { Price = value } };
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void Pass_Throught_Variable_Discount()
		{
			Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
			mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
				.Returns<decimal>(total => total);
			mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v == 0)))
				.Throws<ArgumentOutOfRangeException>();
			mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v > 100)))
				.Returns<decimal>(total => total * 0.9M);
			mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(10,100, Range.Inclusive)))
				.Returns<decimal>(total => total - 5);

			var target = new LinqValueCalculator(mock.Object);

			decimal FiveDollarDiscount = target.ValueProducts(CreateProduc(5));
			decimal TenDollarDiscount = target.ValueProducts(CreateProduc(10));
			decimal FiftyDollarDiscount = target.ValueProducts(CreateProduc(50));
			decimal HundredDollarDiscount = target.ValueProducts(CreateProduc(100));
			decimal FiveHundredDollarDiscount = target.ValueProducts(CreateProduc(500));

			Assert.AreEqual(5, FiveDollarDiscount, "$5 Fail");
			Assert.AreEqual(5, TenDollarDiscount, "$10 Fail");
			Assert.AreEqual(45, FiftyDollarDiscount, "$50 Fail");
			Assert.AreEqual(95, HundredDollarDiscount, "$100 Fail");
			Assert.AreEqual(450, FiveHundredDollarDiscount, "$500 Fail");

			target.ValueProducts(CreateProduc(0));
		}
	}
}
