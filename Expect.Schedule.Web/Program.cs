
using Serilog;

namespace Expect.Schedule.Web
{
	/// <summary>
	/// �������� �����
	/// </summary>
	public class Program
	{
		/// <summary>
		/// ����� �����
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