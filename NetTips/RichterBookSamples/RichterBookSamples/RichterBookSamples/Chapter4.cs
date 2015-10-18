using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichterBookSamples
{
	public static class Chapter4
	{
		public static void Run()
		{
			//MemberWiseClone();
			CheckedUncheckedSection();
		}

		private static void CheckedUncheckedSection()
		{

			try
			{
				byte b = 1;
				//default behaviour
				byte c = (byte)(b + 400);

				checked
				{
					byte d = (byte)(b + 400);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Using block checked we can turn on rasing stack overflow exception");
			}
		}

		class A
		{
			public String StringProperty { get; set; }
			public B BObject { get; set; }
			public int IntProperty { get; set; }
			public A GetNewReferenceForObject()
			{
				return (A)this.MemberwiseClone();
			}
		}
		class B
		{
			public String BStringProperty { get; set; }
			public int BIntProperty { get; set; }
		}

		private static void MemberWiseClone()
		{
			A a = new A();
			a.StringProperty = "Test";
			a.BObject = new B() { BStringProperty = "Hello from a and B" , BIntProperty = 5};
			a.IntProperty = 7;

			A aCopy = a.GetNewReferenceForObject();
			aCopy.StringProperty = "TestUpdate";
			aCopy.IntProperty = 8;
			a.BObject.BStringProperty = "Hello from aCopy and B";
			a.BObject.BIntProperty = 6;

			Console.WriteLine(String.Format("a : {0}, bObject :{1} aCopy :{2}, bObject :{3}", 
				a.StringProperty+a.IntProperty.ToString(), 
				a.BObject.BStringProperty+a.BObject.BIntProperty.ToString(), 
				aCopy.StringProperty+aCopy.IntProperty.ToString(), 
				aCopy.BObject.BStringProperty+aCopy.BObject.BIntProperty.ToString()));
		}
	}
}
