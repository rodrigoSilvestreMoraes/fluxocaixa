using FluxoCaixa.Api.Models;
using FluxoCaixa.Core.Domain.Models.Cliente;
using FluxoCaixa.Core.Domain.Models.Fornecedore;
using FluxoCaixa.Core.Domain.ServiceBusiness.Dominios;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FluxoCaixa.Api.Controllers
{
	/// <summary>
	/// TODO: A idéia dessa controller é prover um meio para listar os dados de domínio existente e que podem ser utilizados por outras operações.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class DomainController : ControllerBase
	{
		readonly IDominioService _dominioService;
		const string _tagSwagger = "Domínio Geral";
		public DomainController(IDominioService dominioService)
		{
			_dominioService = dominioService;
		}

		[HttpGet("clientes/todos")]
		[SwaggerOperation(
		Summary = "Lista todos os Clientes.",
		Description = "Permite a consulta de todos os clientes disponíveis.",
		OperationId = "Listar Clientes", Tags = new[] { _tagSwagger })]
		[SwaggerResponse(StatusCodes.Status200OK, "Solicitação realizada.", typeof(List<ClienteView>))]
		[SwaggerResponse(StatusCodes.Status404NotFound, "Sem resultados.", typeof(ErroPadrao))]
		public async Task<IActionResult> ConsultarTodosClientes()
		{
			var resultOperation = await _dominioService.ListarClientes();
			if (!resultOperation.Any())
				return StatusCode(StatusCodes.Status404NotFound, new ErroPadrao { Code = $"{StatusCodes.Status404NotFound}", Message = new List<string> { "Nenhum registro encontrado." } } );

			return StatusCode(StatusCodes.Status200OK, resultOperation);
		}

		[HttpGet("fornecedores/todos")]
		[SwaggerOperation(
		Summary = "Lista todos os Fornecedores.",
		Description = "Permite a consulta de todos os fornecedores disponíveis.",
		OperationId = "Listar Fornecedores", Tags = new[] { _tagSwagger })]
		[SwaggerResponse(StatusCodes.Status200OK, "Solicitação realizada.", typeof(List<FornecedorView>))]
		[SwaggerResponse(StatusCodes.Status404NotFound, "Sem resultados.", typeof(ErroPadrao))]
		public async Task<IActionResult> ConsultarTodosFornecedores()
		{
			var resultOperation = await _dominioService.ListarFornecedores();
			if (!resultOperation.Any())
				return StatusCode(StatusCodes.Status404NotFound, new ErroPadrao { Code = $"{StatusCodes.Status404NotFound}", Message = new List<string> { "Nenhum registro encontrado." } });

			return StatusCode(StatusCodes.Status200OK, resultOperation);
		}

		[HttpGet("despesas/todas")]
		[SwaggerOperation(
		Summary = "Lista todas as Despesas.",
		Description = "Permite a consulta de todas as despesas disponíveis.",
		OperationId = "Listar Despesas", Tags = new[] { _tagSwagger })]
		[SwaggerResponse(StatusCodes.Status200OK, "Solicitação realizada.", typeof(List<FornecedorView>))]
		[SwaggerResponse(StatusCodes.Status404NotFound, "Sem resultados.", typeof(ErroPadrao))]
		public async Task<IActionResult> ConsultarTodasDespesas()
		{
			var resultOperation = await _dominioService.ListarDespesas();
			if (!resultOperation.Any())
				return StatusCode(StatusCodes.Status404NotFound, new ErroPadrao { Code = $"{StatusCodes.Status404NotFound}", Message = new List<string> { "Nenhum registro encontrado." } });

			return StatusCode(StatusCodes.Status200OK, resultOperation);
		}

		[HttpGet("receitas/todas")]
		[SwaggerOperation(
		Summary = "Lista todas as Receitas.",
		Description = "Permite a consulta de todas as receitas disponíveis.",
		OperationId = "Listar Receitas", Tags = new[] { _tagSwagger })]
		[SwaggerResponse(StatusCodes.Status200OK, "Solicitação realizada.", typeof(List<FornecedorView>))]
		[SwaggerResponse(StatusCodes.Status404NotFound, "Sem resultados.", typeof(ErroPadrao))]
		public async Task<IActionResult> ConsultarTodasReceitas()
		{
			var resultOperation = await _dominioService.ListarReceitas();
			if (!resultOperation.Any())
				return StatusCode(StatusCodes.Status404NotFound, new ErroPadrao { Code = $"{StatusCodes.Status404NotFound}", Message = new List<string> { "Nenhum registro encontrado." } });

			return StatusCode(StatusCodes.Status200OK, resultOperation);
		}
	}
}
