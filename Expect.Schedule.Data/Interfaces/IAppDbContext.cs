using Expect.Schedule.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Schedule.Data.Interfaces
{
	public interface IAppDbContext : IDisposable
	{
		public DbSet<Timetable> Timetables { get; set; }
		public DbSet<Day> Days { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Classroom> Classrooms { get; set; }
		public DbSet<Additional> Additionals { get; set; }

		public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
