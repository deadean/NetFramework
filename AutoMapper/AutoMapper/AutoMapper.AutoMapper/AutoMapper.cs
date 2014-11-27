using NinjectService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.AutoMapper
{
	public class AutoMapper : IAutoMapper
	{
		private static INinjectService service = new NinjectService.NinjectService();

		public IMappingExpression<TI, TR> Register<TI, TR>()
		{
			return Mapper.CreateMap<TI, TR>();
		}

		public T Map<T>(object o)
		{
			return Mapper.Map<T>(o);
		}
	};
}
