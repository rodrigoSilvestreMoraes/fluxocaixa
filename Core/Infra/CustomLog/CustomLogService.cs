using FluxoCaixa.Core.Domain.Models.CustomLog;
using FluxoCaixa.Core.Infra.Repository.CustomLog;

using System.Diagnostics.CodeAnalysis;

namespace FluxoCaixa.Core.Infra.CustomLog
{
	[ExcludeFromCodeCoverage]
	public class CustomLogService : ICustomLogService
	{
		readonly ICustomLogRepo _customLogRepo;
		public CustomLogService(ICustomLogRepo customLogRepo)
		{
			_customLogRepo = customLogRepo;
		}

		public void SaveLog(LogDetail logDetail)
		{
			try
			{
				Console.WriteLine($"{logDetail.Descricao}");
				Console.WriteLine($"{logDetail.Erro}");
				_customLogRepo.GravarLog(logDetail);
				
			}
			catch { }
		}

		public void SaveLogAlert(string modulo, string acao, string message)
		{
			try
			{
				Console.WriteLine($"{modulo} - {acao} - {message}");

				var log = LogDetail.Build(nomeModulo: modulo,
					  nomeAcao: acao,
					  descricao: message,
					  erro: string.Empty,
					  payload: string.Empty,
					  isError: false);

				SaveLog(log);
			}
			catch { }
		}
	}
}
