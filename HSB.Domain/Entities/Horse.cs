using HSB.Domain.Enums;

namespace HSB.Domain.Entities
{
	public class Horse
	{
        public Guid Id { get; set; }
        public double Height { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
		public virtual List<Battle> Battles { get; set; }

	}
}
