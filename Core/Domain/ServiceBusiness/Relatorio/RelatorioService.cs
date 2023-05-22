using FluxoCaixa.Core.Domain.Models.Relatorio;
using FluxoCaixa.Core.Domain.Models.Transacao;
using FluxoCaixa.Core.Infra.Repository.Transacao;


namespace FluxoCaixa.Core.Domain.ServiceBusiness.Relatorio
{
	public class RelatorioService : IRelatorioService
	{
		readonly IRegistroRepo _registroRepo;
		public RelatorioService(IRegistroRepo registroRepo) 
		{ 
			_registroRepo = registroRepo;
		}
		public async Task<SaldoCaixa> GerarRelatorioFluxo(DateTime dataInicial, DateTime dataFinal)
		{
			var result = new SaldoCaixa(dataInicial, dataFinal);
			result.TotalDespesas =  await _registroRepo.TotalSaldoPorPeriodo(dataInicial, dataFinal, RegistroDespesa._collectionName);
			result.TotalReceitas = await _registroRepo.TotalSaldoPorPeriodo(dataInicial, dataFinal, RegistroReceita._collectionName);

			return result;
		}
	}
}
