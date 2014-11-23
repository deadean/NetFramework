using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectSample
{
	public class Car:ICar
	{
		IEngine engine;
		public Car(IEngine engine)
		{
			this.engine = engine;
		}

		public bool Start()
		{
			return engine.StartEngine();
		}
	}
}
