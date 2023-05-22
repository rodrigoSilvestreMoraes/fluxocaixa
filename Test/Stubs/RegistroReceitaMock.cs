using FluxoCaixa.Core.Domain.Models.Transacao;
using FluxoCaixa.Core.Domain.ServiceBusiness.Dominios;
using MongoDB.Bson;
using Moq;

namespace FluxoCaixa.Test.Stubs
{
	public static class RegistroReceitaMock
	{
		public static RegistroReceita MockRegistroReceita(Mock<IDominioService> dominioService)
		{
			return new RegistroReceita(dominioService.Object)
			{
				 Id = ObjectId.GenerateNewId(),
				 CodigoCliente = "dsdsdsd",
				 CodigoReceita = "dsdsdsdsd",
				 DataPagamento = DateTime.Now.AddDays(4),
				 Descricao = "teste",
				 Valor = 100				 
			};
		}
	}
}
