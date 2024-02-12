namespace HSB.Domain.Exceptions.NotFoundExceptions
{
	public class BattleNotFoundException : NotFoundException
	{
        public BattleNotFoundException(Guid battleId) : base($"Battle with identifier {battleId} was not found .")
        {
            
        }
    }
}
