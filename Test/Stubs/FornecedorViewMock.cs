using FluxoCaixa.Core.Domain.Models.Fornecedore;
using MongoDB.Bson;

namespace FluxoCaixa.Test.Stubs
{
	public static class FornecedorViewMock
	{
		public static FornecedorView MockFornecedorView()
		{
			return new FornecedorView
			{
				 Id = ObjectId.GenerateNewId(),
				 Nome = "TESTE"
			};
		}
	}
}
