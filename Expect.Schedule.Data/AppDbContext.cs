using Expect.Schedule.Data.Interfaces;
using Expect.Schedule.Data.Seeding;
using Expect.Schedule.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Schedule.Data
{
	public class AppDbContext : DbContext, IAppDbContext
	{
		#region Entities
		public DbSet<Timetable> Timetables { get; set; }
		public DbSet<Day> Days { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Classroom> Classrooms { get; set; }
		public DbSet<Additional> Additionals { get; set; }
        #endregion

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public AppDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}
	}
}
