using FluxoCaixa.Core.Domain.Models.Despesa;
using MongoDB.Bson;

namespace FluxoCaixa.Test.Stubs
{
	public static  class DespesaViewMock
	{
		public static DespesaView MockDespesaView()
		{
			return new DespesaView
			{
			   Id = ObjectId.GenerateNewId(),
			   Nome = "Teste"
			};
		}

	}
}
