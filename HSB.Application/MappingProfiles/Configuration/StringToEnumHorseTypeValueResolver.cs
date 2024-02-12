using AutoMapper;
using HSB.Application.Dtos;
using HSB.Domain.Entities;
using HSB.Domain.Enums;

namespace HSB.Application.MappingProfiles.Configuration
{
	public class StringToEnumHorseTypeValueResolver : IValueResolver<HorseDto, Horse, Color>
	{
		public Color Resolve(HorseDto source, Horse destination, Color destMember, ResolutionContext context)
		{
			if(Enum.TryParse(source.Color,true,out Color result))
			{
				return result;
			}
			else
			{
				string colorValues = string.Join(",",Enum.GetValues(typeof(Color)).Cast<Color>().Select(x=>x.ToString()));
				throw new AutoMapperMappingException($"Unable to map string {source.Color} to eum {nameof(Color)}s. \n Choose one of the color values : {colorValues}");
			}
		}
	}
}
