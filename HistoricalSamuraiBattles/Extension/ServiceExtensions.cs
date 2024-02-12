using HSB.Application.Service.Contracts;
using HSB.Application.Services;
using HSB.Domain.Contracts;
using HSB.Infrastructure.Data;
using HSB.Infrastructure.Logger;
using HSB.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace HistoricalSamuraiBattles.Extension
{
	public static class ServiceExtensions
	{
		public static void ConfigureCors(this  IServiceCollection services) => 
				services.AddCors(options =>
				{
					options.AddPolicy("Cors",
						c => c.AllowAnyOrigin()
								.AllowAnyHeader()
								.AllowAnyMethod());
				});

		// Sql Configuration 
		public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
				services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"), b=>b.MigrationsAssembly("HistoricalSamuraiBattles")));

		// register Manager Repository 
		public static void ConfigureRepositoryManager(this IServiceCollection services) =>
				services.AddScoped<IRepositoryManager, RepositoryManager>();

		// register Logger Service 
		public static void ConfigureLoggerService(this IServiceCollection services) => 
				services.AddSingleton<ILoggerManager, LoggerManager>();

		// Register Service Manager 
		public static void ConfigureServiceManager(this IServiceCollection services) => 
				services.AddScoped<IServiceManager, ServiceManager>();

		

	}
}
