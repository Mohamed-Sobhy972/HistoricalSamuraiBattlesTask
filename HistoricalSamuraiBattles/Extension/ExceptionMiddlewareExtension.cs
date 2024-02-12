using AutoMapper;
using HSB.Domain.Contracts;
using HSB.Domain.ErrorModels;
using HSB.Domain.Exceptions.NotFoundExceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace HistoricalSamuraiBattles.Extension
{
	internal static class ExceptionMiddlewareExtension
	{
		public static void ConfigureExceptionHandler(this WebApplication app , ILoggerManager logger)
		{
			app.UseExceptionHandler(err =>
			{
				err.Run(async context =>
				{
					context.Response.ContentType = "application/json";
					var exception = context.Features.Get<IExceptionHandlerFeature>();
					if(exception is not null)
					{
						context.Response.StatusCode = exception.Error switch
						{
							NotFoundException => StatusCodes.Status404NotFound,
							_ => StatusCodes.Status400BadRequest
						};

						logger.LogError($"{DateTime.Now} - {exception.Error.Message}");
						await context.Response.WriteAsync(new ErrorModel
						{
							Message = exception.Error is AutoMapperMappingException ? exception.Error.InnerException.Message :  exception.Error.Message,
							StatusCode = context.Response.StatusCode,
							
						}.ToString());
						
					}
				});
			});
		}
	}
}
