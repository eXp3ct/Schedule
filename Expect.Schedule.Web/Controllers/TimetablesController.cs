using Expect.Schedule.Domain.Enums;
using Expect.Schedule.Domain.Models;
using Expect.Schedule.Domain.Results;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Expect.Schedule.Web.Controllers
{
	/// <summary>
	/// Расписания
	/// </summary>
	[ApiController]
	[Route("api/[controller]")]
	[Authorize("schedule")]
	public class TimetablesController : ControllerBase
	{
		private readonly IBus _bus;
		private readonly ILogger<TimetablesController> _logger;

		public TimetablesController(IBus bus, ILogger<TimetablesController> logger)
		{
			_bus = bus;
			_logger = logger;
		}

		[HttpPost]
		public async Task<IActionResult> Add()
		{
			var timetable = new Timetable
			{
				Type = WeekType.Even,
				Id = Guid.NewGuid(),
				Days = new List<Day>
				{
					new Day
					{
						Id = Guid.NewGuid(),
						DayOfWeek = DayOfWeek.Sunday,
					}
				}
			};

			var respond = await _bus.Request<Timetable, OperationResult>(timetable);

			return Ok(respond.Message);
		}
	}
}
