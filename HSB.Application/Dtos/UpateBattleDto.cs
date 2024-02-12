using System.ComponentModel.DataAnnotations;

namespace HSB.Application.Dtos
{
	public record UpateBattleDto
	{
		[Required(ErrorMessage = "Battle Name is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Battle Location is required")]

		public string Location { get; set; }

		[Required(ErrorMessage = "Date for battle is required")]
		public DateTime Date { get; set; }
	}
}
