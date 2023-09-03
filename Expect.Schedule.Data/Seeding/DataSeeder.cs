using Expect.Schedule.Domain.Enums;
using Expect.Schedule.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Schedule.Data.Seeding
{
	public static class DataSeeder
	{
		public static void SeedData(this ModelBuilder builder)
		{
			var classroom = new Classroom
			{
				Hull = "E",
				Id = Guid.NewGuid(),
				Number = 312
			};

			var subject = new Subject
			{
				Id = Guid.NewGuid(),
				Name = "База данных"
			};

			var teacher = new Teacher
			{
				Id = Guid.NewGuid(),
				Institute = "ИФМЕН",
				Position = "Зав.кафедрой"
			};

			var course = new Course
			{
				Id = Guid.NewGuid(),
				Classroom = classroom,
				Subject = subject,
				Teacher = teacher,
				Additional = null,
				TimeEnd = new TimeSpan(9, 0, 0),
				TimeStart = new TimeSpan(10, 30, 0)
			};

			var day = new Day
			{
				Id = Guid.NewGuid(),
				Courses = new List<Course>{ course },
				DayOfWeek = DayOfWeek.Monday
			};

			var timetable = new Timetable
			{
				Id = Guid.NewGuid(),
				Days = new List<Day>{ day },
				Type = WeekType.Even
			};

			builder.Entity<Timetable>().HasData(timetable);
			builder.Entity<Day>().HasData(day);
			builder.Entity<Classroom>().HasData(classroom);
			builder.Entity<Course>().HasData(course);
			builder.Entity<Subject>().HasData(subject);
			builder.Entity<Teacher>().HasData(teacher);
		}
	}
}
