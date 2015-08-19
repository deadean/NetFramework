using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			WebClient client = new WebClient();
			string reply = client.DownloadString("http://localhost:50349/Home/AutoProperty");

			Assert.IsTrue(reply.Contains("Product"));

		}
	}
}
