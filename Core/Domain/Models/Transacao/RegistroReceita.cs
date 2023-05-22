using FluxoCaixa.Core.Domain.ServiceBusiness.Dominios;

namespace FluxoCaixa.Core.Domain.Models.Transacao
{
	public class RegistroReceita : RegistroTransacaoBase
	{
		readonly IDominioService _dominioService;
		public const string _collectionName = "RegistroReceitas";

		public RegistroReceita(IDominioService dominioService)
		{
			_dominioService = dominioService;
		}

		public string CodigoReceita { get; set; }
		public string CodigoCliente { get; set; }
		public async Task<List<string>> Validar()
		{
			var result = new List<string>();

			var receita = await _dominioService.ConsultarReceita(CodigoReceita);
			if (receita == null)
				result.Add("Receita não existe no cadastro.");

			if (!string.IsNullOrEmpty(CodigoCliente))
			{
				var cliente = await _dominioService.ConsultarCliente(CodigoCliente);
				if (cliente == null)
					result.Add("Cliente não existe no cadastro.");
			}

			if (Valor <= 0)
				result.Add("Valor da despesa não pode ser menor ou igual a 0.");

			return result;
		}
		public new void ProcessarStatus() => base.ProcessarStatus();
	}
}
