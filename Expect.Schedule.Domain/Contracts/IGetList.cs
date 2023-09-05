using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Schedule.Domain.Contracts
{
	public interface IGetList
	{
		public int Page { get; }
		public int PageSize { get; }
	}
}
