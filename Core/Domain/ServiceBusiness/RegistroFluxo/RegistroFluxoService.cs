using FluxoCaixa.Core.Domain.Models.CustomLog;
using FluxoCaixa.Core.Domain.Models.Transacao;
using FluxoCaixa.Core.Infra.CustomLog;
using FluxoCaixa.Core.Infra.Mongo;
using FluxoCaixa.Core.Infra.Repository.Transacao;
using System.Reflection;

namespace FluxoCaixa.Core.Domain.ServiceBusiness.RegistroFluxo
{
	public class RegistroFluxoService : IRegistroFluxoService
	{
		readonly IRegistroRepo _registroRepo;
		readonly ICustomLogService _customLogService;

		const string _module = "RegistroFluxoService";
		public RegistroFluxoService(IRegistroRepo registroRepo, ICustomLogService customLogService)
		{
			_registroRepo = registroRepo;
			_customLogService = customLogService;
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

				_customLogService.SaveLogAlert(_module, "RegistrarDespesa", "Despesa registrada com sucesso.");
				return result;
			}
			catch (Exception ex)
			{
				_customLogService.SaveLog(LogDetail.Build(
					_module,
					nomeAcao: "RegistrarDespesa",
					descricao: "Falha ao executar RegistroFluxoService",
					erro: ex.Message + "-" + ex.StackTrace,
					payload: string.Empty,
					isError: true));

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

				_customLogService.SaveLogAlert(_module, "RegistrarReceita", "Receita registrada com sucesso.");
				return result;
			}
			catch (Exception ex)
			{
				_customLogService.SaveLog(LogDetail.Build(
				_module,
				nomeAcao: "RegistrarDespesa",
				descricao: "Falha ao executar RegistroFluxoService",
				erro: ex.Message + "-" + ex.StackTrace,
				payload: string.Empty,
				isError: true));

				result.Erros.Add($"Falha na operação de registro de receita: {ex.Message}");
			}

			return result;
		}
	}
}
