using HSB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HSB.Infrastructure.Configuration
{
	public class BattleConfiguration : IEntityTypeConfiguration<Battle>
	{
		public void Configure(EntityTypeBuilder<Battle> builder)
		{
			builder.HasData(new Battle[]
			{
				new Battle
				{
					 Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
					 Name = "Tofan Al-Aqsa",
					 Location = "Gaza",
					 Date = new DateTime(2023,10,7)
				}
			});

			builder.HasMany(h => h.Horses)
				.WithMany(b => b.Battles)
				.UsingEntity(hb => hb.HasData(new 
				{ 
					BattlesId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), 
					HorsesId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") 
				},
				new 
				{ 
					BattlesId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), 
					HorsesId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3") 
				}));

			builder.HasMany(s => s.Samurais)
				.WithMany(b => b.Battles)
				.UsingEntity(sb => sb.HasData(
					new {
						BattlesId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
						SamuraisId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")
					},
					new
					{
						BattlesId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
						SamuraisId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a")
					}

					));
		}
	}
}
