using HSB.Application.Dtos;
using HSB.Domain.Entities;

namespace HSB.Application.Service.Contracts
{
	public interface IHorseService
	{
		Task<IEnumerable<HorseDto>> GetAllHorsesAsync(bool trackChanges);
		Task<HorseDto> GetHorseAsync(Guid horseId, bool trackChanges);
		Task<Horse> CreateHorseAsync(HorseDto horseDto);
		Task DeleteHorse(Guid horseId, bool trackChanges);
		Task<Horse> UpdateHorse(HorseDto horseForUpdate, Guid horseId, bool trackChanges);
	}
}
