using FluxoCaixa.Core.Domain.Models.Cliente;
using MongoDB.Bson;

namespace FluxoCaixa.Test.Stubs
{
	public static class ClienteViewMock
	{
		public static ClienteView MockClienteView()
		{
			return new ClienteView
			{
				Id = ObjectId.GenerateNewId(),
				Nome = "TESTE"
			};
		}
	}
}
