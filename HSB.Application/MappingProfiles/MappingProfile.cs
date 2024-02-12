using AutoMapper;
using HSB.Application.Dtos;
using HSB.Application.MappingProfiles.Configuration;
using HSB.Domain.Entities;

namespace HSB.Application.MappingProfiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{

			CreateMap<Battle, BattleDto>()
			 .ForMember(dest => dest.Horses, opt => opt.MapFrom(src => src.Horses))
			 .ForMember(dest => dest.Samurais, opt => opt.MapFrom(src => src.Samurais));

			CreateMap <CreationBattleDto, Battle>()
				.ForMember(dest => dest.Horses, opt => opt.Ignore())
				.ForMember(dest => dest.Samurais, opt => opt.Ignore());

			CreateMap<UpateBattleDto, Battle>()
				.ForMember(dest => dest.Horses, opt => opt.Ignore())
				.ForMember(dest => dest.Samurais, opt => opt.Ignore());

			CreateMap<Horse, HorseDto>();

			CreateMap<HorseDto, Horse>()
				.ForMember(dest => dest.Color,
					opt => opt.MapFrom<StringToEnumHorseTypeValueResolver>());

			CreateMap<Samurai, SamuraiDto>();

			CreateMap<SamuraiDto, Samurai>()
				.ForMember(dest => dest.Type,
					opt => opt.MapFrom<StringToEnumSamuraiTypeValueResolver>());


		}
    }
}
