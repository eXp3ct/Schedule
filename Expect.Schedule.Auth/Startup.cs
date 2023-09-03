namespace Expect.Schedule.Auth
{
	public class Startup
	{
		private readonly IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
		{
			app.UseRouting();
			app.UseIdentityServer();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddIdentityServer()
				.AddInMemoryApiResources(Configuration.GetApiResources())
				.AddInMemoryApiScopes(Configuration.GetApiScopes())
				.AddInMemoryClients(Configuration.GetClients())
				.AddDeveloperSigningCredential();
		}
	}
}
