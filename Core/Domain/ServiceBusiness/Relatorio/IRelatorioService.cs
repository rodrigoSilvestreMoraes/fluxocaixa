using FluxoCaixa.Core.Domain.Models.Relatorio;

namespace FluxoCaixa.Core.Domain.ServiceBusiness.Relatorio
{
	public interface IRelatorioService
	{
		Task<SaldoCaixa> GerarRelatorioFluxo(DateTime dataInicial, DateTime dataFinal);
	}
}
