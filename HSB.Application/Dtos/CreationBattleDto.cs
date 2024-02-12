using System.ComponentModel.DataAnnotations;

namespace HSB.Application.Dtos
{
	public record CreationBattleDto
	{
		[Required(ErrorMessage = "Battle Name is required")]
		public string Name { get; init; }
		[Required(ErrorMessage = "Battle Location is required")]
		public string Location { get; init; }
		[Required(ErrorMessage = "Date for battle is required")]
		public DateTime Date { get; init; }
		[Required(ErrorMessage ="Can’t create battle without horses")]
		public List<Guid> HorsesIds { get; set; }

		[Required(ErrorMessage = "Can’t create battle without samurais")]
		public List<Guid> SamuraisIds { get; set; }
	}
}
