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
			var timetable = await _unitOfWork.TimetableRepository.Add(context.Message);

			var result = default(OperationResult);

			if(timetable == null)
			{
				_logger.LogWarning($"Timetable {context.Message.Id} cannot be added to database");
				result = new OperationResult(null, false);

				await context.RespondAsync(result);

				return;
			}

			result = new OperationResult(timetable, true);

			await _unitOfWork.Save();

			_logger.LogInformation($"Timetable {context.Message.Id} was added to database");

			await context.RespondAsync(result);
		}
	}
}
