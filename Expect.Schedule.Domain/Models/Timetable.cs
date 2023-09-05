using Expect.Schedule.Domain.Enums;
using Expect.Schedule.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Schedule.Domain.Models
{
	public class Timetable : IEntity
	{
		public Guid Id { get; set; }
		public WeekType Type { get; set; }
		public List<Day> Days { get; set; }
	}

	public class TimetableDto
	{
		public WeekType Type { get; set; }
		public List<DayDto> DayDtos { get; set; }
	}
}
