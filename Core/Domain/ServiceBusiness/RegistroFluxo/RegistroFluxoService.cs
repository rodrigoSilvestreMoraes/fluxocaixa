using FluxoCaixa.Core.Domain.Models.Transacao;
using FluxoCaixa.Core.Infra.Mongo;
using FluxoCaixa.Core.Infra.Repository.Transacao;

namespace FluxoCaixa.Core.Domain.ServiceBusiness.RegistroFluxo
{
	public class RegistroFluxoService : IRegistroFluxoService
	{
		readonly IRegistroRepo _registroRepo;
		public RegistroFluxoService(IRegistroRepo registroRepo)
		{
			_registroRepo = registroRepo;
		}
		public async Task<ResultadoRegistro<RegistroDespesa>> RegistrarDespesa(RegistroDespesa despesa)
		{
			var result = new ResultadoRegistro<RegistroDespesa>();
			try
			{
				var validacao = await despesa.Validar();
				if(validacao.Any()) 
				{
					result.Erros = validacao;
					return result;
				}

				despesa.ProcessarStatus();
				var resultInsercao = await _registroRepo.CriarDespesa(despesa);
				if(resultInsercao != null && FunctionsOperation.IsCreateOperationExecuting(resultInsercao.Id))
				{
					result.Data = resultInsercao;
					result.Erro = false;
				}
				return result;
			}
			catch (Exception ex)
			{
				//TODO:  Gerar lol
				result.Erros.Add($"Falha na operação de registro de despesa: {ex.Message}");				
			}

			return result;
		}

		public async Task<ResultadoRegistro<RegistroReceita>> RegistrarReceita(RegistroReceita receita)
		{
			var result = new ResultadoRegistro<RegistroReceita>();
			try
			{
				var validacao = await receita.Validar();
				if (validacao.Any())
				{
					result.Erros = validacao;
					return result;
				}

				receita.ProcessarStatus();
				var resultInsercao = await _registroRepo.CriarReceita(receita);
				if (resultInsercao != null && FunctionsOperation.IsCreateOperationExecuting(resultInsercao.Id))
				{
					result.Data = resultInsercao;
					result.Erro = false;
				}
				return result;
			}
			catch (Exception ex)
			{
				//TODO:  Gerar lol
				result.Erros.Add($"Falha na operação de registro de receita: {ex.Message}");
			}

			return result;
		}
	}
}
