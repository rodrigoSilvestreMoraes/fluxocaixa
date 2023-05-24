using FluxoCaixa.Api.Annotation;
using FluxoCaixa.Core.Domain.Models.Transacao;
using FluxoCaixa.Core.Domain.ServiceBusiness.Dominios;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

using FluxoCaixa.Core.Infra.Extension;

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
			return new RegistroDespesa(dominioService, Codigo, CodigoFornecedor)
			{
				Descricao = Descricao,
				DataPagamento = DataPagamento.DateTimeParse(),
				Valor = Valor
			};
		}
	}
}
