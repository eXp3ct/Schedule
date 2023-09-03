using IdentityServer4.Models;

namespace Expect.Schedule.Auth
{
	public static class Configuration
	{
		public static IEnumerable<ApiResource> GetApiResources()
		{
			return new List<ApiResource>
			{
				new ApiResource("schedule", "Schedules Web API")
				{
					Scopes = {"schedule:write", "schedule:read"}
				},
				new ApiResource("users", "Users Web API")
				{
					Scopes = {"users:write", "users:read"}
				}
			};
		}

		public static IEnumerable<ApiScope> GetApiScopes()
		{
			return new List<ApiScope>
			{
				new ApiScope("schedule:write", "Schedules Web API Write"),
				new ApiScope("schedule:read", "Schedules Web API Read"),
				new ApiScope("users:read", "Users Web API Read"),
				new ApiScope("users:write", "Users Web API Write"),
			};
		}

		public static IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile()
			};
		}

		public static IEnumerable<Client> GetClients()
		{
			return new List<Client>
			{
				new Client
				{
					ClientId = "admin",
					AllowedGrantTypes = GrantTypes.ClientCredentials,
					ClientSecrets =
					{
						new Secret("admin".Sha256())
					},
					AllowedScopes =
					{
						"schedule:write",
						"schedule:read"
					},
				},
				new Client
				{
					ClientId = "dev",
					AllowedGrantTypes = GrantTypes.ClientCredentials,
					ClientSecrets =
					{
						new Secret("dev".Sha256())
					},
					AllowedScopes =
					{
						"schedule:write",
						"schedule:read",
						"users:write",
						"users:read"
					}
				}
			};
		}
	}
}
