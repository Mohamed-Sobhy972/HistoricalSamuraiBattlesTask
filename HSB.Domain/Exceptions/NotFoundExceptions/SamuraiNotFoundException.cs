namespace HSB.Domain.Exceptions.NotFoundExceptions
{
	public class SamuraiNotFoundException : NotFoundException
	{
        public SamuraiNotFoundException(Guid samuraiId) : base($"Samurai with identifier {samuraiId} was not found") { }
        
    }
}
