using System.ComponentModel.DataAnnotations;

namespace HSB.Application.Dtos
{
	public record SamuraiDto
	{
		[Required(ErrorMessage = "Horse Name is required")]
		public string Name { get; init; }

		[Required(ErrorMessage = "Horse Type is required")]
		public string Type { get; init; }
        public Guid? horseId { get; init; }
    }
}
