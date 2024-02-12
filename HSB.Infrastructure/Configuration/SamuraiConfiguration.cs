using HSB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HSB.Infrastructure.Configuration
{
	public class SamuraiConfiguration : IEntityTypeConfiguration<Samurai>
	{
		public void Configure(EntityTypeBuilder<Samurai> builder)
		{
			builder.HasData(new List<Samurai>
			{
				new Samurai
				{
					Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
					Name = "Warrior Samurai",
					Type = Domain.Enums.SamuraiType.Warrior,
					HorseId= new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
				},
				new Samurai
				{
					Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
					Name = "Trojan Samurai",
					Type = Domain.Enums.SamuraiType.Trojan,
					HorseId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
				}
			});
		}
	}
}
