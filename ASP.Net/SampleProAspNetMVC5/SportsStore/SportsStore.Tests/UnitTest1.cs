using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;
using SportsStore.WebUI.Models;
using SportsStore.WebUI.HtmlHelpers;

namespace SportsStore.Tests
{
	[TestClass]
	public class UnitTest1
	{
		private readonly Mock<IProductRepository> mock;
    public UnitTest1()
		{
			mock = new Mock<IProductRepository>();
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
		}

		[TestMethod]
		public void Can_Generate_Page_Links()
		{
			HtmlHelper myHelper = null;
			PagingInfo pagingInfo = new PagingInfo
			{
				CurrentPage = 2,
				TotalItems = 4,
				ItemsPerPage = 1
			};

			Func<int, string> pageUrlDelegate = i => "Page" + i;
			MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);
			Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
			+@"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
			+@"<a class=""btn btn-default"" href=""Page3"">3</a>"
			, result.ToString());
		}

		[TestMethod]
		public void Can_Send_Pagination_View_Model()
		{
			ProductController controller = new ProductController(mock.Object);
			controller.PageSize = 3;

			ProductsListViewModel vm = (ProductsListViewModel)controller.List(2).Model;
			PagingInfo pageInfo = vm.PagingInfo;
			Assert.AreEqual(pageInfo.CurrentPage, 2);
			Assert.AreEqual(pageInfo.ItemsPerPage, 3);
			Assert.AreEqual(pageInfo.TotalItems, 5);
			Assert.AreEqual(pageInfo.TotalPages, 2);
		}
	}
}
