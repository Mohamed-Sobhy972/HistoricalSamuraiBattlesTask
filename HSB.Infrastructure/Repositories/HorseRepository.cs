using HSB.Domain.Contracts;
using HSB.Domain.Entities;
using HSB.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HSB.Infrastructure.Repositories
{
	public class HorseRepository : RepositoryBase<Horse>, IHorseRepository
	{
        public HorseRepository(Context context):base(context)
        {
            
        }
		public async Task<IEnumerable<Horse>> GetAllHorsesAsync(bool trackChanges) =>
			 await FindAll(trackChanges)
					.OrderBy(h => h.Name)
					.ToListAsync();

		public async Task<IEnumerable<Horse>> GetHorsesByConditionAsync(Expression<Func<Horse, bool>> expression,
							bool trackChanges) => 
			await FindAllByCondition(expression, trackChanges)
					.OrderBy(h=>h.Name)
					.ToListAsync();

		public async Task<Horse> GetHorse(Guid horseId, bool trackChanges) =>
			await FindAllByCondition(h => h.Id == horseId, trackChanges)
					.SingleOrDefaultAsync();
		public void CreateHorse(Horse horse) => Create(horse);

		public void DeleteHorse(Horse horse) => Delete(horse);

		public void UpdateHorse(Horse horse) => Update(horse);
	}
}
