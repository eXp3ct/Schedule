﻿using Expect.Schedule.Data.UnitOfWorks;
using Expect.Schedule.Domain.Contracts;
using Expect.Schedule.Domain.Results;
using MassTransit;

namespace Expect.Schedule.ScheduleService.Consumers
{
	public class GetListConsumer : IConsumer<IGetList>
	{
		private readonly UnitOfWork _unitOfWork;

		public GetListConsumer(UnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task Consume(ConsumeContext<IGetList> context)
		{
			var list = await _unitOfWork.TimetableRepository.GetList(context.Message.Page, context.Message.PageSize);

			var result = default(OperationResult);

			if(list == null)
			{
				result = new OperationResult(null, false);

				await context.RespondAsync(result);

				return;
			}

			result = new OperationResult(list, true);

			await context.RespondAsync(result);
		}
	}
}
