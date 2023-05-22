using FluxoCaixa.Core.Domain.Models.Receita;
using MongoDB.Bson;

namespace FluxoCaixa.Test.Stubs
{
	public static class ReceitaViewMock
	{
		public static ReceitaView MockReceitaView()
		{
			return new ReceitaView
			{
				Id = ObjectId.GenerateNewId(),
				Nome = "TESTE"
			};
		}
	}
}