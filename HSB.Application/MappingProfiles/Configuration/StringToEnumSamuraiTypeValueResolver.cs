using AutoMapper;
using HSB.Application.Dtos;
using HSB.Domain.Entities;
using HSB.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSB.Application.MappingProfiles.Configuration
{
	public class StringToEnumSamuraiTypeValueResolver : IValueResolver<SamuraiDto, Samurai, SamuraiType>
	{
		public SamuraiType Resolve(SamuraiDto source, Samurai destination, SamuraiType destMember, ResolutionContext context)
		{
			if(Enum.TryParse(source.Type,true, out SamuraiType result))
			{
				return result;
			}
			else
			{
				string samuraiTypes = string.Join(",", Enum.GetValues(typeof(SamuraiType)).Cast<SamuraiType>().Select(x => x.ToString()));
				throw new AutoMapperMappingException($"Unable to map string {source.Type} to enum {nameof(SamuraiType)}s. \n Choose one of the types values : {samuraiTypes}");
			}
		}
	}
}
