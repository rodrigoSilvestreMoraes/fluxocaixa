using FluxoCaixa.Core.Domain.ServiceBusiness.Relatorio;
using FluxoCaixa.Core.Infra.Repository.Transacao;
using Moq;

namespace FluxoCaixa.Test.Core.Domain.ServiceBusiness.Relatorio
{
	public class RelatorioServiceTest
	{
		readonly Mock<IRegistroRepo> _registroRepo;
		public RelatorioServiceTest()
		{
			_registroRepo = new Mock<IRegistroRepo>();
		}

		[Fact]
		public async void Deveria_GerarRelatorioFluxo()
		{
			decimal valorTotalDespesa = 5000;
			decimal valorTotalReceita = 10000;

			_registroRepo.Setup(x => x.TotalSaldoPorPeriodo(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsIn<string>("RegistroDespesas"))).Returns(Task.FromResult(valorTotalDespesa));
			_registroRepo.Setup(x => x.TotalSaldoPorPeriodo(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsIn<string>("RegistroReceitas"))).Returns(Task.FromResult(valorTotalReceita));

			var result = await GetService().GerarRelatorioFluxo(DateTime.Now.AddDays(-10), DateTime.Now);
			Assert.NotNull(result);
			Assert.True(result.Saldo == 5000);
		}

		[Fact]
		public async void Nao_Deveria_GerarRelatorioFluxo_DataInvalida()
		{
			_ = Assert.ThrowsAsync<InvalidOperationException>(async () => await GetService().GerarRelatorioFluxo(DateTime.Now.AddDays(10), DateTime.Now));
		}

		IRelatorioService GetService() => new RelatorioService(_registroRepo.Object);
	}
}
