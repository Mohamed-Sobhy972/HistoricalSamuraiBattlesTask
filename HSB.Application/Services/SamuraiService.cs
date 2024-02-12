using AutoMapper;
using HSB.Application.Dtos;
using HSB.Application.Service.Contracts;
using HSB.Domain.Contracts;
using HSB.Domain.Entities;
using HSB.Domain.Exceptions.NotFoundExceptions;

namespace HSB.Application.Services
{
	public class SamuraiService : ISamuraiService
	{
		private readonly IRepositoryManager _repository;
		private readonly IMapper _mapper;
		public SamuraiService(IRepositoryManager repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task<IEnumerable<SamuraiDto>> GetSamuraisAsync(bool trackChanges)
		{
			var samurais = await _repository.Samurai.GetAllSamuriesAsync(trackChanges);

			var samuraisDto = _mapper.Map<IEnumerable<SamuraiDto>>(samurais);

			return samuraisDto;
		}

		public async Task<SamuraiDto> GetSamuraiAsync(Guid samuraiId, bool trackChanges)
		{
			var samurai = await _repository.Samurai.GetSamuraiAsync(samuraiId, trackChanges);

			if (samurai is null)
				throw new SamuraiNotFoundException(samuraiId);

			var samuraiDto = _mapper.Map<SamuraiDto>(samurai);

			return samuraiDto;

		}



		public async Task<Samurai> CreateSamurai(SamuraiDto samuraiDto)
		{
			var samuraiEntity = _mapper.Map<Samurai>(samuraiDto);

			if(samuraiDto.horseId is not null)
			{
				var horse = await _repository.Horse.GetHorse((Guid)samuraiDto.horseId, true);

				if (horse is null)
					throw new HorseNotFoundException((Guid)samuraiDto.horseId);
			}
			_repository.Samurai.CreateSamurai(samuraiEntity);

			await _repository.SaveAsync();

			return samuraiEntity;
		}

		public async Task<Samurai> UpdateSamurai(SamuraiDto samuraiForUpdate, Guid samuraiId, bool trackChanges)
		{
			var samuraiEntity = await _repository.Samurai.GetSamuraiAsync(samuraiId, trackChanges);

			if (samuraiEntity is null)
				throw new SamuraiNotFoundException(samuraiId);

			_mapper.Map(samuraiForUpdate, samuraiEntity);

			await _repository.SaveAsync();

			return samuraiEntity;
		}

		public async Task<Samurai> DeleteSamurai(Guid samuraiId, bool trackChanges)
		{
			var samuraiEntity = await _repository.Samurai.GetSamuraiAsync(samuraiId, trackChanges);
			if (samuraiEntity is null)
				throw new SamuraiNotFoundException(samuraiId);

			_repository.Samurai.DeleteSamurai(samuraiEntity);
			await _repository.SaveAsync();
			return samuraiEntity;
		}
	}
}
