using Expect.Schedule.Data;
using Expect.Schedule.Domain.Configurations;
using Expect.Schedule.Domain.Models;
using Expect.Schedule.ScheduleService.Consumers;
using MassTransit;

namespace Expect.Schedule.ScheduleService
{
	public class Startup
	{
		private readonly IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{

		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddPersistance(_configuration);
			services.AddMassTransit(x =>
			{
				x.SetKebabCaseEndpointNameFormatter();
				x.AddConsumer<TimetableConsumer>();
				x.UsingRabbitMq((context, config) =>
				{
					var rabbitMqConfig = _configuration
					.GetSection("RabbitMqOptions")
					.Get<RabbitMqOptions>()
					?? throw new InvalidOperationException("Cannot create RabbitMq configuration");

					config.Host(rabbitMqConfig.Host, "/", host =>
					{
						host.Username(rabbitMqConfig.Username);
						host.Password(rabbitMqConfig.Password);
					});

					config.ConfigureEndpoints(context);
				});
			});
		}
	}
}
