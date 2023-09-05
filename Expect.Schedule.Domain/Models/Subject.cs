using Expect.Schedule.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Schedule.Domain.Models
{
	public class Subject : IEntity
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
	}

	public class SubjectDto
	{
		public string Name { get; set; }
	}
}
