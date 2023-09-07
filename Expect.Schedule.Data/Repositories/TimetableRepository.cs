using Expect.Schedule.Data.Interfaces;
using Expect.Schedule.Domain.Models;
using Expect.Schedule.Domain.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Schedule.Data.Repositories
{
	public class TimetableRepository : IRepository<Timetable>
	{
		private readonly IAppDbContext _context;

		public TimetableRepository(IAppDbContext appDbContext)
		{
			_context = appDbContext;
		}

		public async Task<Timetable> Add(Timetable entity)
		{
			var entry = await _context.Timetables.AddAsync(entity);

			return entry.Entity;
		}

		public async Task<Timetable> Delete(Guid id)
		{
			var entity = await _context.Timetables.FindAsync(id);

			if(entity == null)
			{
				return new Timetable();
			}

			var entry = _context.Timetables.Remove(entity);

			return entry.Entity;
		}

		public async Task<Timetable> Get(Guid id)
		{
			var entity = await _context.Timetables.FindAsync(id);

			if(entity == null)
			{
				return new Timetable();
			}

			return entity;
		}

		public async Task<IEnumerable<Timetable>> GetList(int page, int pageSize)
		{
			var entities = await _context.Timetables
											.Include(t => t.Days)
												.ThenInclude(d => d.Courses)
													.ThenInclude(c => c.Subject)
											.Include(t => t.Days)
												.ThenInclude(d => d.Courses)
													.ThenInclude(c => c.Teacher)
											.Include(t => t.Days)
												.ThenInclude(d => d.Courses)
													.ThenInclude(c => c.Classroom)
											.Include(t => t.Days)
												.ThenInclude(d => d.Courses)
													.ThenInclude(c => c.Additional)
											.Skip((page - 1) * pageSize)
											.Take(pageSize)
											.ToListAsync();
			return entities;
		}

		public async Task<Timetable> Update(Guid id, Timetable newEntity)
		{
			var entity = await _context.Timetables.FindAsync(id);

			if (entity == null)
			{
				return new Timetable();
			}

			entity = newEntity;

			return entity;
		}
	}
}
