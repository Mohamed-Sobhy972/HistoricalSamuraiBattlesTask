using HSB.Domain.Contracts;
using HSB.Domain.Entities;
using HSB.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HSB.Infrastructure.Repositories
{
	public class BattleRepository : RepositoryBase<Battle> , IBattleRepository
	{
        public BattleRepository(Context context) : base(context)
        {
            
        }
		public async Task<IEnumerable<Battle>> GetAllBattles(bool trackChanges) =>
			await FindAll(trackChanges)
					.OrderBy(b => b.Name)
					.ToListAsync();

		public async Task<Battle> GetBattle(Guid battleId, bool trackChanges) =>
			await FindAllByCondition(b => b.Id == battleId, trackChanges)
					.SingleOrDefaultAsync();
		public  void CreateBattle(Battle battle) =>  Create(battle);


		public void DeleteBattle(Battle battle) => Delete(battle);

		public void UpdateBattle(Battle battle) => Update(battle);
		
	}
}
