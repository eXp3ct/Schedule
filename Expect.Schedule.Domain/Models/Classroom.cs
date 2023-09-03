using Expect.Schedule.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Schedule.Domain.Models
{
	public class Classroom : IEntity
	{
		public Guid Id { get; set; }
		public string Hull { get; set; }
		public int Number { get; set; }
	}
}
