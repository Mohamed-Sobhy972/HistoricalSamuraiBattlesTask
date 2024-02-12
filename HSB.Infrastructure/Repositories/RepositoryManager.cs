using HSB.Domain.Contracts;
using HSB.Infrastructure.Data;

namespace HSB.Infrastructure.Repositories
{
	public class RepositoryManager : IRepositoryManager
	{
		public IBattleRepository Battle => _battleRepository.Value;

		public IHorseRepository Horse => _horseRepository.Value;

		public ISamuraiRepository Samurai => _samuraiRepository.Value;
		public  async Task SaveAsync() => await _context.SaveChangesAsync();

		private readonly Context _context;
		private readonly Lazy<ISamuraiRepository> _samuraiRepository;
		private readonly Lazy<IHorseRepository> _horseRepository;
		private readonly Lazy<IBattleRepository> _battleRepository;

        public RepositoryManager(Context context)
        {
			_context = context;
			_samuraiRepository = new Lazy<ISamuraiRepository>(() => new SamuraiRepository(_context));
			_horseRepository = new Lazy<IHorseRepository>(() => new HorseRepository(_context));
			_battleRepository= new Lazy<IBattleRepository>(() => new BattleRepository(_context));

		}

    }
}
