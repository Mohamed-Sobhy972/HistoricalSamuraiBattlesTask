using HSB.Domain.Contracts;
using HSB.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HSB.Infrastructure.Repositories
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		private readonly Context _context;

		public RepositoryBase(Context context)
		{
			_context = context;
		}
		public IQueryable<T> FindAll(bool trackChanges) =>
			trackChanges ? _context.Set<T>().AsNoTracking() :
			_context.Set<T>();
		

		public IQueryable<T> FindAllByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
			trackChanges ?  _context.Set<T>().Where(expression).AsNoTracking() :
			_context.Set<T>().Where(expression);

		public IQueryable<bool> IsExistsByIds(Expression<Func<T, bool>> expression) =>
			_context.Set<T>().Select(expression);

		public void Create(T entity) => _context.Set<T>().Add(entity);
		public void Delete(T entity) => _context.Set<T>().Remove(entity);
		public void Update(T entity) => _context.Set<T>().Update(entity);

	
	}
}
