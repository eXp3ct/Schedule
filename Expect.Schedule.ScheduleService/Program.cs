using Expect.Schedule.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Expect.Schedule.ScheduleService
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			using var scope = host.Services.CreateScope();
			using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();	
			context.Database.Migrate();

			host.Run();
		}


		private static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.UseSerilog((context, config) =>
				{
					config
						.MinimumLevel.Information()
						.WriteTo.Console();
				})
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}