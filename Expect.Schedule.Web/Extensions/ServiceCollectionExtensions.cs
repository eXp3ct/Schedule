namespace Expect.Schedule.Web.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddPolicy(this IServiceCollection services, string claimType, params string[] allowedValues)
		{
			services.AddAuthorization(options =>
			{
				options.AddPolicy(claimType, policy =>
				{
					policy.RequireClaim("scope", allowedValues);
				});
			});
		}
	}
}
