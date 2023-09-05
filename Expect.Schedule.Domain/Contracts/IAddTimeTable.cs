using Expect.Schedule.Domain.Enums;
using Expect.Schedule.Domain.Models;

namespace Expect.Schedule.Domain.Contracts
{
	public interface IAddTimeTable
	{
		public WeekType Type { get; set; }
		public List<DayDto> DayDtos { get; set; }
	}

	public class AddTimetableDto : IAddTimeTable
	{
		public WeekType Type { get; set; }
		public List<DayDto> DayDtos { get; set; }
	}
}
