using FluxoCaixa.Core.Domain.ServiceBusiness.Dominios;
using FluxoCaixa.Core.Domain.ServiceBusiness.RegistroFluxo;
using FluxoCaixa.Core.Infra.CustomLog;
using FluxoCaixa.Core.Infra.EventBus;
using FluxoCaixa.Core.Infra.Mongo;
using FluxoCaixa.Core.Infra.Repository.CustomLog;
using FluxoCaixa.Core.Infra.Repository.Dominio;
using FluxoCaixa.Core.Infra.Repository.Transacao;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace FluxoCaixa.Core.Infra.BootStrap
{
	[ExcludeFromCodeCoverage]
	public static class StartupBuilderFluxoCaixaCore
	{
		public static IConfiguration BuildSettings(IConfiguration _configuration)
		{
			_configuration = ConfigureSettings(_configuration);
			return _configuration;
		}

		public static IServiceCollection BuildServices(IServiceCollection services, IConfiguration _configuration)
		{
			#region Services

			services.AddSingleton<BackgroundWorkerQueue>();
			services.AddSingleton<IRegistroFluxoService, RegistroFluxoService>();
			services.AddSingleton<ICustomLogService, CustomLogService>();			

			#endregion

			#region Repositories

			var _mongoConfig = new MongoClient(new MongoConfig
			{
				User = _configuration.GetSection("MongoConfig:User").Value,
				Password = _configuration.GetSection("MongoConfig:Password").Value,
				ConnectionString = _configuration.GetSection("MongoConfig:ConnectionString").Value,
				DataBaseName = _configuration.GetSection("MongoConfig:DataBaseName").Value
			});

			services.AddSingleton<IMongoClient, MongoClient>();			
			
			services.AddSingleton<IDominioService>(x => new DominiosRepo(mongoClient: _mongoConfig));
			services.AddSingleton<IRegistroRepo>(x => new RegistroRepo(mongoClient: _mongoConfig));
			services.AddSingleton<ICustomLogRepo>(x => new CustomLogRepo(mongoClient: _mongoConfig, x.GetRequiredService<BackgroundWorkerQueue>()));			

			#endregion

			return services;
		}

		static IConfiguration ConfigureSettings(IConfiguration _configuration)
		{
			return _configuration;
		}
	}
}
