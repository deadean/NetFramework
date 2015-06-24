using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorsAndFields
{
	class Program
	{
		static void Main(string[] args)
		{
			A a = new A();
		}
	}

	class A
	{
		protected int _field;

		public A()
		{
			_field = 9;
		}

		public A(int b):this()
		{

		}
	}

	class B : A
	{
		public B()
		{
			_field = 10;
		}
	}
}
