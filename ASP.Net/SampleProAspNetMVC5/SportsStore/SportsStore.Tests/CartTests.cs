using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;

namespace SportsStore.Tests
{
	[TestClass]
	public class CartTests:BaseTest
	{
		public CartTests()
		{
		}

		[TestMethod]
		public void Can_Add_New_Lines()
		{
			Cart target = new Cart();
			target.AddItem(mock.Object.Products.First(), 1);
			target.AddItem(mock.Object.Products.First(), 2);

			Assert.AreEqual(target.Lines.Count(), 1);
			Assert.AreEqual(target.Lines.First().Product, mock.Object.Products.First());
		}

		[TestMethod]
		public void Can_Remove_Lines()
		{
			Cart target = new Cart();
			target.AddItem(mock.Object.Products.First(), 1);
			target.AddItem(mock.Object.Products.First(), 2);

			target.RemoveLine(mock.Object.Products.First());

			Assert.AreEqual(target.Lines.Count(), 0);
		}

		[TestMethod]
		public void Can_Calculate_Lines_Total()
		{
			Cart target = new Cart();
			target.AddItem(mock.Object.Products.First(), 1);
			target.AddItem(mock.Object.Products.First(), 2);

			Assert.AreEqual(target.ComputeTotalValue(), 300M);
		}

		[TestMethod]
		public void Can_Clear_Lines_Cart()
		{
			Cart target = new Cart();
			target.AddItem(mock.Object.Products.First(), 1);
			target.AddItem(mock.Object.Products.First(), 2);

			target.Clear();

			Assert.AreEqual(target.Lines.Count(), 0);
		}
	}
}
