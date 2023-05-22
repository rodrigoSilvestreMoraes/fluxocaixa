using FluxoCaixa.Core.Domain.Models.Transacao;

namespace FluxoCaixa.Core.Domain.ServiceBusiness.RegistroFluxo
{
	public interface IRegistroFluxoService
	{
		Task<ResultadoRegistro<RegistroDespesa>> RegistrarDespesa(RegistroDespesa despesa);
		Task<ResultadoRegistro<RegistroReceita>> RegistrarReceita(RegistroReceita receita);
	}
}
