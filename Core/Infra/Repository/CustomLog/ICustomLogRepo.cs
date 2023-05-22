using FluxoCaixa.Core.Domain.Models.CustomLog;

namespace FluxoCaixa.Core.Infra.Repository.CustomLog
{
	public interface ICustomLogRepo
	{
		void GravarLog(LogDetail logDetail);
	}
}
