using AutoMapper;
using HSB.Application.Dtos;
using HSB.Application.Service.Contracts;
using HSB.Domain.Contracts;
using HSB.Domain.Entities;
using HSB.Domain.Exceptions.NotFoundExceptions;

namespace HSB.Application.Services
{
	public class HorseService : IHorseService
	{
		private readonly IRepositoryManager _repository;
		private readonly IMapper _mapper;

		public HorseService(IRepositoryManager repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}


		public async Task<IEnumerable<HorseDto>> GetAllHorsesAsync(bool trackChanges)
		{
			var horses = await _repository.Horse.GetAllHorsesAsync(trackChanges);

			var horsesDto = _mapper.Map<List<HorseDto>>(horses);

			return horsesDto;
		}

		public async Task<HorseDto> GetHorseAsync(Guid horseId, bool trackChanges)
		{
			var horse = await _repository.Horse.GetHorse(horseId, trackChanges);

			if (horse is null)
				throw new HorseNotFoundException(horseId);

			var horseDto = _mapper.Map<HorseDto>(horse);

			return horseDto;
		}

		public async Task<Horse> CreateHorseAsync(HorseDto horseDto)
		{
			var horse = _mapper.Map<Horse>(horseDto);

			_repository.Horse.CreateHorse(horse);

			await _repository.SaveAsync();

			return horse;
		}

		public async Task DeleteHorse(Guid horseId, bool trackChanges)
		{
			var horse = await _repository.Horse.GetHorse(horseId,trackChanges);

            if (horse is null)
            {
				throw new HorseNotFoundException(horseId);
            }

            _repository.Horse.DeleteHorse(horse);
			await _repository.SaveAsync();
		}

		public async Task<Horse> UpdateHorse(HorseDto horseForUpdate, Guid horseId, bool trackChanges)
		{
			var entityHorse = await _repository.Horse.GetHorse(horseId, trackChanges);

			if(entityHorse is null)
			{
				throw new HorseNotFoundException(horseId);
			}
			_mapper.Map(horseForUpdate, entityHorse);

			_repository.Horse.UpdateHorse(entityHorse);

			await _repository.SaveAsync();

			return entityHorse;

		}
	}
}
