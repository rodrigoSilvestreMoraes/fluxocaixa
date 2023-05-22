using FluxoCaixa.Api.Models.Transacao;
using FluxoCaixa.Core.Domain.ServiceBusiness.Relatorio;
using Microsoft.AspNetCore.Mvc;

using FluxoCaixa.Core.Infra.Extension;
using FluxoCaixa.Api.Models;
using Swashbuckle.AspNetCore.Annotations;
using FluxoCaixa.Core.Domain.Models.Relatorio;

namespace FluxoCaixa.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RelatorioController : ControllerBase
	{
		readonly IRelatorioService _relatorioService;

		public RelatorioController(IRelatorioService relatorioService) 
		{ 
			_relatorioService = relatorioService;
		}

		[HttpGet]
		[SwaggerOperation(
		Summary = "Consulta o saldo do caixa, baseado no perído informado, calculo o total de receitas - despesas.",
		Description = "Consulta o saldo do caixa, baseado no perído informado, calculo o total de receitas - despesas.",
		OperationId = "Transações", Tags = new[] { "Relatório de Caixa" })]
		[SwaggerResponse(StatusCodes.Status200OK, "Solicitação inválida.", typeof(List<SaldoCaixa>))]
		[SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Informações inválidas no request.", typeof(ErroPadrao))]
		public async Task<IActionResult> Get([FromQuery] RelatorioRequest relatorioRequest) 
		{
			var result = await _relatorioService.GerarRelatorioFluxo(relatorioRequest.DataInicial.DateTimeParse(), relatorioRequest.DataFinal.DateTimeParse());
			return Ok(result);
		}
	}
}
