﻿namespace HSB.Domain.Exceptions.NotFoundExceptions
{
	public abstract class NotFoundException : Exception
	{
		protected NotFoundException(string message) : base(message) { }
	}
}
