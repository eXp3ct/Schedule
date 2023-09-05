using Expect.Schedule.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Schedule.Domain.Models
{
	public class Additional : IEntity
	{
		public Guid Id { get; set; }
		public string Header { get; set; }
		public string Description { get; set; }
	}
	
	public class AdditionalDto
	{
		public string Header { get; set; }
		public string Description { get; set; }
	}
}
