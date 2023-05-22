using FluxoCaixa.Api.Models;
using FluxoCaixa.Api.Models.Transacao;
using FluxoCaixa.Core.Domain.ServiceBusiness.Dominios;
using FluxoCaixa.Core.Domain.ServiceBusiness.RegistroFluxo;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FluxoCaixa.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegistroController : ControllerBase
	{
		readonly IRegistroFluxoService _registroFluxoService;
		readonly IDominioService _dominioService;
		public RegistroController(IRegistroFluxoService registroFluxoService, IDominioService dominioService) 
		{ 
			_registroFluxoService = registroFluxoService;
			_dominioService = dominioService;
		}

		[HttpPost("despesa")]
		[SwaggerOperation(
		Summary = "Permite o registro de uma determinada despesa.",
		Description = "Permite o registro de uma determinada despesa.",
		OperationId = "Transações", Tags = new[] { "Despesas" })]
		[SwaggerResponse(StatusCodes.Status400BadRequest, "Solicitação inválida.", typeof(List<ErroPadrao>))]
		[SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Informações inválidas no request.", typeof(ErroPadrao))]
		public async Task<IActionResult> CriarDespesa([FromBody] DespesaRequest despesaRequest)
		{
			var resultOperation = await _registroFluxoService.RegistrarDespesa(despesaRequest.Mapping(_dominioService));
			if (!resultOperation.Erro)
				return StatusCode(StatusCodes.Status201Created, resultOperation.Data);

			var erro = new ErroPadrao { Code = "StatusCodes.Status422UnprocessableEntity", Message = resultOperation.Erros };
			return StatusCode(StatusCodes.Status422UnprocessableEntity, erro);
		}

		[HttpPost("receita")]
		[SwaggerOperation(
		Summary = "Permite o registro de uma determinada receita.",
		Description = "Permite o registro de uma determinada receita.",
		OperationId = "Transações", Tags = new[] { "Receitas" })]
		[SwaggerResponse(StatusCodes.Status400BadRequest, "Solicitação inválida.", typeof(List<ErroPadrao>))]
		[SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Informações inválidas no request.", typeof(ErroPadrao))]
		public async Task<IActionResult> CriarReceita([FromBody] ReceitaRequest receitaRequest)
		{
			var resultOperation = await _registroFluxoService.RegistrarReceita(receitaRequest.Mapping(_dominioService));
			if (!resultOperation.Erro)
				return StatusCode(StatusCodes.Status201Created, resultOperation.Data);

			var erro = new ErroPadrao { Code = "StatusCodes.Status422UnprocessableEntity", Message = resultOperation.Erros };
			return StatusCode(StatusCodes.Status422UnprocessableEntity, erro);
		}
	}
}
