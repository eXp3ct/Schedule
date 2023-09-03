using Expect.Schedule.Data.Interfaces;
using Expect.Schedule.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Schedule.Data.UnitOfWorks
{
	public class UnitOfWork : IDisposable
	{
		private readonly IAppDbContext _context;
		private TimetableRepository _timetableRepository;

		public TimetableRepository TimetableRepository
		{
			get
			{
				return _timetableRepository ??= new TimetableRepository(_context);
			}
		}

		public UnitOfWork(IAppDbContext context)
		{
			_context = context;
		}

		public Task Save()
		{
			return _context.SaveChangesAsync();
		}

		private bool disposed = false;

		public virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
