using NinjectService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.AutoMapper
{
	public interface IAutoMapper
	{

		IMappingExpression<TI, TR> Register<TI, TR>();

		T Map<T>(object o);

	}
}
