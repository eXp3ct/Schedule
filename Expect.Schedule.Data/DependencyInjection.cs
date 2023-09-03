using Expect.Schedule.Data.Interfaces;
using Expect.Schedule.Data.Repositories;
using Expect.Schedule.Data.UnitOfWorks;
using Expect.Schedule.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Schedule.Data
{
	public static class DependencyInjection
	{
		public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseNpgsql(connectionString);
			});

			services.AddScoped<IAppDbContext,  AppDbContext>();
			services.AddScoped<IRepository<Timetable>, TimetableRepository>();
			services.AddScoped<UnitOfWork>();
		}
	}
}
