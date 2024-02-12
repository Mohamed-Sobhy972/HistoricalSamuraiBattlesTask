namespace HSB.Application.Dtos
{
	public record BattleDto (string Name, string Location, DateTime Date, List<HorseDto> Horses, List<SamuraiDto> Samurais)
	{
		

	}
}
