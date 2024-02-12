using System.ComponentModel.DataAnnotations;

namespace HSB.Application.Dtos
{
	public record HorseDto
	{
		[Required(ErrorMessage ="Horse Name is required")]
		public string Name { get; init; }
		[Required(ErrorMessage ="Horse Height is required")]
		[Range(1.0,2.5 , ErrorMessage ="Height Should be within 1m to 2.5m")]
        public double Height { get; init; }
		[Required(ErrorMessage = "Horse Color is required")]
        public string Color { get; init; }
    }
}
