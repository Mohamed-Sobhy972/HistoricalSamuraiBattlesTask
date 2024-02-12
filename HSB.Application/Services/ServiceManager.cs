using AutoMapper;
using HSB.Application.Service.Contracts;
using HSB.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSB.Application.Services
{
	public class ServiceManager : IServiceManager
	{
		public IHorseService HorseService => _horseService.Value;

		public ISamuraiService SamuraiService => _samuraiService.Value;

		public IBattleService BattleService => _battleService.Value;

		public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_horseService = new Lazy<IHorseService>(() => new HorseService(repositoryManager, mapper));
			_samuraiService = new Lazy<ISamuraiService>(() => new SamuraiService(repositoryManager, mapper));
			_battleService = new Lazy<IBattleService>(() => new BattleService(repositoryManager, mapper));
		}
		
		private readonly Lazy<IHorseService> _horseService;
		private readonly Lazy<ISamuraiService> _samuraiService; 
		private readonly Lazy<IBattleService> _battleService;
    }
}
