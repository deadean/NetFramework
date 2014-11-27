using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectService
{
	public interface INinjectService
	{
		void Register<TI, TR>() where TR : TI;

		T Get<T>();
	}
}
