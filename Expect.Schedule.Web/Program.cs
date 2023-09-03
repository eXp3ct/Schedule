
using Serilog;

namespace Expect.Schedule.Web
{
	/// <summary>
	/// Основной класс
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Точка входа
		/// </summary>
		/// <param name="args"></param>
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
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