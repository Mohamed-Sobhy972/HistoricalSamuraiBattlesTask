using HSB.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HSB.Domain.Entities
{
	public class Samurai
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
        public SamuraiType Type { get; set; }
		[ForeignKey(nameof(Horse))]
        public Guid? HorseId { get; set; }
        public virtual Horse Horse { get; set; }
		public virtual List<Battle> Battles { get; set; }

	}
}
