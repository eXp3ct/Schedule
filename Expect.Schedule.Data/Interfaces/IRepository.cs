using Expect.Schedule.Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Schedule.Data.Interfaces
{
	public interface IRepository<TEntity> where TEntity : IEntity
	{
		public Task<TEntity> Get(Guid id);
		public Task<IEnumerable<TEntity>> GetList(int page, int pageSize);
		public Task<TEntity> Delete(Guid id);
		public Task<TEntity> Update(Guid id, TEntity newEntity);
		public Task<TEntity> Add(TEntity entity);
	}
}
