using Expect.Schedule.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Schedule.Domain.Results
{
	public class OperationResult : IEntity
	{
		public Guid Id { get; set; }
		public object? Data { get; set; }
		public bool IsSuccess { get; set; }
		public DateTime DateTime { get; set; }

        public OperationResult(object? data, bool isSuccess)
        {
            Id = Guid.NewGuid();
			Data = data;
			IsSuccess = isSuccess;
			DateTime = DateTime.Now;
        }
    }
}
