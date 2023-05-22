using FluxoCaixa.Api.Annotation;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace FluxoCaixa.Api.Models.Transacao
{
	public class RelatorioRequest
	{

		[Required(ErrorMessage = "Data Inicial é obrigatório.")]
		[SwaggerSchema("A data deve estar no formato yyyy-mm-dd")]
		[StringLength(10, MinimumLength = 10, ErrorMessage = "Formatação da data inválida, yyyy-mm-dd")]
		[CustomDateValidate]
		public string DataInicial { get; set; }

		[Required(ErrorMessage = "Data Inicial é obrigatório.")]
		[SwaggerSchema("A data deve estar no formato yyyy-mm-dd")]
		[StringLength(10, MinimumLength = 10, ErrorMessage = "Formatação da data inválida, yyyy-mm-dd")]
		[CustomDateValidate]
		public string DataFinal { get; set; }
	}
}
