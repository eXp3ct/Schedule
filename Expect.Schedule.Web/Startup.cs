using Expect.Schedule.Domain.Configurations;
using Expect.Schedule.Infrastructure;
using Expect.Schedule.Web.Extensions;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Logging;

namespace Expect.Schedule.Web
{

	/// <summary>
	/// Конфигурация WebApi
	/// </summary>
	public class Startup
	{
		private readonly IConfiguration _configuration;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="configuration"></param>
		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		/// <summary>
		/// Конфигурация web api
		/// </summary>
		/// <param name="app"></param>
		/// <param name="environment"></param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
		{
			if (environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		/// <summary>
		/// Конфигурация сервисов
		/// </summary>
		/// <param name="services"></param>
		/// <exception cref="InvalidOperationException"></exception>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

			SwaggerOptions.Configure(services);

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
				{
					options.Authority = "http://schedule-auth:80";
					options.Audience = "schedule";
					options.TokenValidationParameters = new()
					{
						ValidateIssuer = false,
					};
					options.RequireHttpsMetadata = false;
				});
			
			services.AddMassTransit(x =>
			{
				x.SetKebabCaseEndpointNameFormatter();
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
				});
			});

			AddPolicies(services);
			services.AddInfrastructure();
		}

		private static void AddPolicies(IServiceCollection services)
		{
			services.AddPolicy("schedule", "schedule:write", "schedule:read");
			services.AddPolicy("schedule:read", "schedule:read");
			services.AddPolicy("schedule:write", "schedule:write");

			services.AddPolicy("users", "users:write", "users:read");
			services.AddPolicy("users:read", "users:read");
			services.AddPolicy("users:write", "users:write");
		}
	}
}
