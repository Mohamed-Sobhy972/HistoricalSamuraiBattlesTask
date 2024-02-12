using HSB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HSB.Infrastructure.Configuration
{
	public class HorseConfiguraiton : IEntityTypeConfiguration<Horse>
	{
		public void Configure(EntityTypeBuilder<Horse> builder)
		{
			builder.HasData(new Horse[] {
				new Horse
				{
					Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
					Name ="Black Horse",
					Color = Domain.Enums.Color.Black,
					Height = 2.1
				},
				new Horse
				{
					Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
					Name="White Horse",
					Color = Domain.Enums.Color.White,
					Height = 2.5
				}
			});
		}
	}
}
