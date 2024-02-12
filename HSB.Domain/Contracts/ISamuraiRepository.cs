using HSB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HSB.Domain.Contracts
{
	public interface ISamuraiRepository
	{
		Task<IEnumerable<Samurai>> GetAllSamuriesAsync(bool trackChanges);
		Task<IEnumerable<Samurai>> GetSamurisByConditionAsync(Expression<Func<Samurai, bool>> expression,
							bool trackChanges);
		Task<Samurai> GetSamuraiAsync(Guid samurai, bool trackChanges);
		IEnumerable<bool> CheckHorsesRodeBySamurai(List<Guid> samurisIds, List<Guid> HorsesIds);
		void CreateSamurai(Samurai samurai);
		void UpdateSamurai(Samurai samurai);
		void DeleteSamurai(Samurai samurai);
	}
}
