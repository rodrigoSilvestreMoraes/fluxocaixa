using FluxoCaixa.Core.Domain.Models.CustomLog;

namespace FluxoCaixa.Core.Infra.CustomLog
{
	public interface ICustomLogService
	{
		void SaveLog(LogDetail logDetail);
		void SaveLogAlert(string modulo, string acao, string message);
	}
}
