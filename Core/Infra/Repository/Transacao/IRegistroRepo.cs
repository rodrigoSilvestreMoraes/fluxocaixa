using FluxoCaixa.Core.Domain.Models.Transacao;

namespace FluxoCaixa.Core.Infra.Repository.Transacao
{
	public interface IRegistroRepo
	{
		Task<RegistroDespesa> CriarDespesa(RegistroDespesa registroDespesa);
		Task<RegistroReceita> CriarReceita(RegistroReceita registroReceita);
	}
}
