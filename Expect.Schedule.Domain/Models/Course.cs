using Expect.Schedule.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Schedule.Domain.Models
{
	public class Course : IEntity
	{
		public Guid Id { get; set; }
		public TimeSpan TimeStart { get; set; }
		public TimeSpan TimeEnd { get; set; }
		public Subject Subject { get; set; }
		public Teacher Teacher { get; set; }
		public Classroom Classroom { get; set; }
		public Additional? Additional { get; set; }
	}

	public class CourseDto
	{
		public string TimeStart { get; set; }
		public string TimeEnd { get; set; }
		public SubjectDto SubjectDto { get; set; }
		public TeacherDto TeacherDto { get; set; }
		public ClassroomDto ClassroomDto { get; set; }
		public AdditionalDto? AdditionalDto { get; set; }
	}
}
