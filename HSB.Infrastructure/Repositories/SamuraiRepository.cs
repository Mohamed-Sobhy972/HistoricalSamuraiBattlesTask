using HSB.Domain.Contracts;
using HSB.Domain.Entities;
using HSB.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HSB.Infrastructure.Repositories
{
	public class SamuraiRepository : RepositoryBase<Samurai>, ISamuraiRepository
	{
		public SamuraiRepository(Context context) :base(context) {}
		public async Task<IEnumerable<Samurai>> GetAllSamuriesAsync(bool trackChanges) =>
			await FindAll(trackChanges)
					.OrderBy(s=>s.Name)
					.ToListAsync();
		public async Task<IEnumerable<Samurai>> GetSamurisByConditionAsync(Expression<Func<Samurai, bool>> expression,
							bool trackChanges) =>
			await FindAllByCondition(expression, trackChanges)
					.OrderBy(h => h.Name)
					.ToListAsync();

		public async Task<Samurai> GetSamuraiAsync(Guid samuraiId, bool trackChanges) =>
			await FindAllByCondition(s => s.Id == samuraiId, trackChanges)
					.SingleOrDefaultAsync();

		public IEnumerable<bool> CheckHorsesRodeBySamurai(List<Guid> samurisIds, List<Guid> HorsesIds) =>
				IsExistsByIds(s => samurisIds.Contains(s.Id) &&  HorsesIds.Contains(s.HorseId.Value));

		public void CreateSamurai(Samurai samurai) => Create(samurai);

		public void DeleteSamurai(Samurai samurai) => Delete(samurai);
		public void UpdateSamurai(Samurai samurai) => Update(samurai);
	}
}
