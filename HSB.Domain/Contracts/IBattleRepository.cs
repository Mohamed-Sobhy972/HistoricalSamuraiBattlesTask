using HSB.Domain.Entities;

namespace HSB.Domain.Contracts
{
	public interface IBattleRepository
	{
		Task<IEnumerable<Battle>> GetAllBattles(bool trackChanges);
		Task<Battle> GetBattle(Guid battleId, bool trackChanges);
		void CreateBattle(Battle battle);
		void UpdateBattle(Battle battle);
		void DeleteBattle(Battle battle);
	}
}
