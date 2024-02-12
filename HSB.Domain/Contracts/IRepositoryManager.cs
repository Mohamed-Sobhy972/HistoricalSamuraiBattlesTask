using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSB.Domain.Contracts
{
	public interface IRepositoryManager
	{
		IBattleRepository Battle { get; }
		IHorseRepository Horse { get; }
		ISamuraiRepository Samurai { get; }
		Task SaveAsync();
	}
}
