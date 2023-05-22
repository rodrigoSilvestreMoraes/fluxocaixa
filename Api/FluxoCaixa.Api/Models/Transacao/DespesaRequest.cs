using FluxoCaixa.Api.Annotation;
using FluxoCaixa.Core.Domain.Models.Transacao;
using FluxoCaixa.Core.Domain.ServiceBusiness.Dominios;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace FluxoCaixa.Api.Models.Transacao
{
	[SwaggerSchema(Required = new[] { "Payload para registro de despesas." })]
	public class DespesaRequest
	{
		[Required(ErrorMessage = "Código da despesa é obrigatório.")]
		public string Codigo { get; set; }

		[Required(ErrorMessage = "Descrição da despesa é obrigatório.")]
		public string Descricao { get; set; }
		public string CodigoFornecedor { get; set;}

		[Required(ErrorMessage = "Valor é obrigatório.")]
		public decimal Valor { get; set; }

		[Required(ErrorMessage = "DataPagamento é obrigatório.")]
		[SwaggerSchema("A data deve estar no formato yyyy-mm-dd")]
		[StringLength(10, MinimumLength = 10, ErrorMessage = "Formatação da data inválida, yyyy-mm-dd")]
		[CustomDateValidate]
		public string DataPagamento { get; set; }

		public RegistroDespesa Mapping(IDominioService dominioService)
		{
			var dataPagamento = DataPagamento.Split('-');
			var year = int.Parse(dataPagamento[0]);
			var month = int.Parse(dataPagamento[1]);
			var day = int.Parse(dataPagamento[2]);

			return new RegistroDespesa(dominioService)
			{
				CodigoDespesa = Codigo,
				Descricao = Descricao,
				CodigoFornecedor = CodigoFornecedor,
				DataPagamento = new DateTime(year, month, day),
				Valor = Valor
			};
		}
	}
}
