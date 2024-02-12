using HSB.Application.Dtos;
using HSB.Domain.Entities;

namespace HSB.Application.Service.Contracts
{
	public interface IBattleService
	{
		Task<IEnumerable<BattleDto>> GetBattlesAsync(bool trackChanges);
		Task<BattleDto> GetBattleAsync(Guid battleId,bool trackChanges);
		Task<Battle> CreateBattle(CreationBattleDto battle);
		Task<Battle> UpdateBattle(UpateBattleDto battleForUpdate, Guid battleId, bool trackChanges);
		Task<Battle> DeleteBattle(Guid battleId, bool trackChanges);
	}
}
