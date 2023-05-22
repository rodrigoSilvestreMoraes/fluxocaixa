using FluxoCaixa.Core.Domain.Models.Cliente;
using FluxoCaixa.Core.Domain.Models.Despesa;
using FluxoCaixa.Core.Domain.Models.Fornecedore;
using FluxoCaixa.Core.Domain.Models.Receita;

namespace FluxoCaixa.Core.Domain.ServiceBusiness.Dominios
{
	public interface IDominioService
	{
		Task<List<ClienteView>> ListarClientes();
		Task<List<FornecedorView>> ListarFornecedores();
		Task<List<DespesaView>> ListarDespesas();
		Task<List<ReceitaView>> ListarReceitas();

		Task<ClienteView> ConsultarCliente(string id);
		Task<FornecedorView> ConsultarFornecedor(string id);
		Task<DespesaView> ConsultarDespesa(string id);
		Task<ReceitaView> ConsultarReceita(string id);
	}
}
