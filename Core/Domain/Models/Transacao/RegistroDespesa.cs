using FluxoCaixa.Core.Domain.ServiceBusiness.Dominios;

namespace FluxoCaixa.Core.Domain.Models.Transacao
{
	public class RegistroDespesa : RegistroTransacaoBase
	{
		readonly IDominioService _dominioService;
		public const string _collectionName = "RegistroDespesas";
		public RegistroDespesa(IDominioService dominioService) 
		{ 
			_dominioService	= dominioService;
		}
		public string CodigoDespesa { get;set; }
		public string CodigoFornecedor { get; set; } 
		public async Task<List<string>>  Validar()
		{
			var result = new List<string>();

			var despesa = await _dominioService.ConsultarDespesa(CodigoDespesa);
			if (despesa == null)
				result.Add("Despesa não existe no cadastro.");

			if (!string.IsNullOrEmpty(CodigoFornecedor))
			{
				var fornecedor = await _dominioService.ConsultarFornecedor(CodigoFornecedor);
				if (fornecedor == null)
					result.Add("Fornecedor não existe no cadastro.");
			}

			if(Valor <=0)
				result.Add("Valor da despesa não pode ser menor ou igual a 0.");

			return result;
		}
		public new void ProcessarStatus() => base.ProcessarStatus();		
	}
}
