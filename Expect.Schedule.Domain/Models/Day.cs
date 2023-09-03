using Expect.Schedule.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Schedule.Domain.Models
{
	public class Day : IEntity
	{
		public Guid Id { get; set; }
		public DayOfWeek DayOfWeek { get; set; }
		public List<Course> Courses { get; set; }
	}
}
