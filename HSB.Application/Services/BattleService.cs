using AutoMapper;
using HSB.Application.Dtos;
using HSB.Application.Service.Contracts;
using HSB.Domain.Contracts;
using HSB.Domain.Entities;
using HSB.Domain.Exceptions.NotFoundExceptions;

namespace HSB.Application.Services
{
	public class BattleService : IBattleService
	{
		private readonly IRepositoryManager _repository;
		private readonly IMapper _mapper;

		public BattleService(IRepositoryManager repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}


		public async Task<IEnumerable<BattleDto>> GetBattlesAsync(bool trackChanges)
		{
			var battles = await _repository.Battle.GetAllBattles(trackChanges);
			

			var battlesDto = _mapper.Map<IEnumerable<BattleDto>>(battles);

			return battlesDto;
		}
		public async Task<BattleDto> GetBattleAsync(Guid battleId, bool trackChanges)
		{
			var battle = await _repository.Battle.GetBattle(battleId, trackChanges);

			if (battle is null)
				throw new BattleNotFoundException(battleId);

			var battleDto = _mapper.Map<BattleDto>(battle);

			return battleDto;
		}

		public async Task<Battle> CreateBattle(CreationBattleDto battle)
		{
			// Check if the samurai rode existing horse
		
			var sammurisAndHorsesJoinedBattle = await _repository.Samurai.GetSamurisByConditionAsync(s => battle.SamuraisIds.Contains(s.Id) && battle.HorsesIds.Contains(s.HorseId.Value),true);


			if(sammurisAndHorsesJoinedBattle.Count() != battle.SamuraisIds.Count && sammurisAndHorsesJoinedBattle.Count() != battle.HorsesIds.Count )
			{
				throw new Exception("Samurais not rode the exisiting Horses.");
			}

			var samurisJoinedBattle = await _repository.Samurai.GetSamurisByConditionAsync(s => battle.SamuraisIds.Contains(s.Id),false);

			var horsesJoinedBattle = await _repository.Horse.GetHorsesByConditionAsync(h=> battle.HorsesIds.Contains(h.Id),false);

			var battleEntity = _mapper.Map<Battle>(battle);

			foreach(var item in  samurisJoinedBattle)
			{
				battleEntity.Samurais.Add(item);

			}
			foreach (var item in horsesJoinedBattle)
			{
				battleEntity.Horses.Add(item);

			}

			_repository.Battle.CreateBattle(battleEntity);

			await _repository.SaveAsync();

			return battleEntity;
		}

		public async Task<Battle> UpdateBattle(UpateBattleDto battleForUpdate, Guid battleId, bool trackChanges)
		{
			var entityBattle = await _repository.Battle.GetBattle(battleId, trackChanges);

			if (entityBattle is null)
				throw new BattleNotFoundException(battleId);

			_mapper.Map(battleForUpdate, entityBattle);

			_repository.Battle.UpdateBattle(entityBattle);
			await _repository.SaveAsync();

			return entityBattle;
		}

		public async Task<Battle> DeleteBattle(Guid battleId, bool trackChanges)
		{
			var entityBattle = await _repository.Battle.GetBattle(battleId, trackChanges);

			if (entityBattle is null)
				throw new BattleNotFoundException(battleId);

			_repository.Battle.DeleteBattle(entityBattle);
			await _repository.SaveAsync();

			return entityBattle;
		}
	}
}
