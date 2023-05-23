using FluxoCaixa.Core.Domain.Models.Cliente;
using MongoDB.Bson;

namespace FluxoCaixa.Test.Stubs
{
	public static class ClienteViewMock
	{
		public static List<ClienteView> Listar()
		{
			var result = new List<ClienteView>();

			for (int i = 0; i < 5; i++)
			{
				result.Add(MockClienteView());
			}
			return result;
		}

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
