namespace HSB.Domain.Exceptions.NotFoundExceptions
{
	public class HorseNotFoundException : NotFoundException
	{
        public HorseNotFoundException(Guid horseId) : base($"The horse with identifier {horseId} was not found")
        {
            
        }
		public HorseNotFoundException(List<Guid> horsesIds) : base($"The horses with identifiers :{string.Join(',',horsesIds) } was not found")
		{

		}
	}
}
