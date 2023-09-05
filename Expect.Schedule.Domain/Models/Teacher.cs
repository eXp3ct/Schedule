using Expect.Schedule.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Schedule.Domain.Models
{
	public class Teacher : IEntity
	{
		public Guid Id { get; set; }
		public string Position { get; set; }
		public string Institute { get; set; }
	}

    public class  TeacherDto
    {
        public string Position { get; set; }
		public string Institute { get; set; }	
    }
}
