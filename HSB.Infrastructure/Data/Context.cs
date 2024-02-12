using HSB.Domain.Entities;
using HSB.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace HSB.Infrastructure.Data
{
	public class Context : DbContext
	{
		public Context(DbContextOptions options):base(options) { }

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Horse> Horses { get; set; }
        public DbSet<Battle> Battles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new HorseConfiguraiton());
			modelBuilder.ApplyConfiguration(new SamuraiConfiguration());
			modelBuilder.ApplyConfiguration(new BattleConfiguration());
		}
	}
}
