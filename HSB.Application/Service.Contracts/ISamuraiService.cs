using HSB.Application.Dtos;
using HSB.Domain.Entities;

namespace HSB.Application.Service.Contracts
{
	public interface ISamuraiService
	{
		Task<IEnumerable<SamuraiDto>> GetSamuraisAsync(bool trackChanges);
		Task<SamuraiDto> GetSamuraiAsync(Guid samuraiId, bool trackChanges);
		Task<Samurai> CreateSamurai(SamuraiDto samuraiDto);
		Task<Samurai> UpdateSamurai(SamuraiDto newSamuraiDto, Guid Id, bool trackChanges);
		Task<Samurai> DeleteSamurai(Guid samuraiId, bool trackChanges);
	}
}
