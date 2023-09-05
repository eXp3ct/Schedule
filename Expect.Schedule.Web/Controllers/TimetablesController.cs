using Expect.Schedule.Domain.Contracts;
using Expect.Schedule.Domain.Results;
using Expect.Schedule.Infrastructure.Commands.Producing.AddTimetable;
using Expect.Schedule.Infrastructure.Commands.Producing.GetListTimetable;
using MediatR;
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
		private readonly IMediator _mediator;
		private readonly ILogger<TimetablesController> _logger;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bus"></param>
		/// <param name="logger"></param>
		public TimetablesController(ILogger<TimetablesController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		/// <summary>
		/// Добавление расписания
		/// </summary>
		/// <param name="dto">Информация о расписания</param>
		/// <returns></returns>
		[HttpPost]
		[ProducesResponseType(200, Type = typeof(OperationResult))]
		public async Task<IActionResult> Add([FromBody] AddTimetableDto dto)
		{
			var query = new AddTimetableQuery(dto);
			var response = await _mediator.Send(query);

			return Ok(response);
		}

		/// <summary>
		/// Получение списка расписания
		/// </summary>
		/// <param name="page">Номер страницы</param>
		/// <param name="pageSize">Размер страницы</param>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(OperationResult))]
		public async Task<IActionResult> Get(int page, int pageSize)
		{
			var query = new GetListTimetableQuery(page, pageSize);

			var reponse = await _mediator.Send(query);

			return Ok(reponse);
		}
	}
}
