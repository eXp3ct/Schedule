using Expect.Schedule.Data.UnitOfWorks;
using Expect.Schedule.Domain.Models;
using Expect.Schedule.Domain.Results;
using MassTransit;

namespace Expect.Schedule.ScheduleService.Consumers
{
	public class TimetableConsumer : IConsumer<Timetable>
	{
		private readonly UnitOfWork _unitOfWork;
		private readonly ILogger<TimetableConsumer> _logger;
		public TimetableConsumer(UnitOfWork unitOfWork, ILogger<TimetableConsumer> logger)
		{
			_unitOfWork = unitOfWork;
			_logger = logger;
		}

		public async Task Consume(ConsumeContext<Timetable> context)
		{
			var timetables = await _unitOfWork.TimetableRepository.GetList(1, 10);

			var result = new OperationResult()
			{
				Data = timetables
			};

			await context.RespondAsync(result);
		}
	}
}
