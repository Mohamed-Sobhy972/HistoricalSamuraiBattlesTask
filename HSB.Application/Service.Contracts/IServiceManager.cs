using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSB.Application.Service.Contracts
{
	public interface IServiceManager
	{
		IHorseService HorseService { get; }
		ISamuraiService SamuraiService { get; }
		IBattleService BattleService { get; }

	}
}
