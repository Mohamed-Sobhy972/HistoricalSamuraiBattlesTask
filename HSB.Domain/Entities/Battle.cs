namespace HSB.Domain.Entities
{
	public class Battle
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public virtual List<Horse> Horses { get; set; } = new List<Horse>();
        public virtual List<Samurai> Samurais { get; set; } = new List<Samurai>();
    }
}
