using HSB.Domain.Entities;
using System.Linq.Expressions;

namespace HSB.Domain.Contracts
{
	public interface IHorseRepository
	{
		Task<IEnumerable<Horse>> GetAllHorsesAsync(bool trackChanges);
		Task<IEnumerable<Horse>> GetHorsesByConditionAsync(Expression<Func<Horse, bool>> expression,
							bool trackChanges);
		Task<Horse> GetHorse(Guid horseId,bool  trackChanges);
		void CreateHorse(Horse horse);
		void UpdateHorse(Horse horse);
		void DeleteHorse(Horse horse);
	}
}
