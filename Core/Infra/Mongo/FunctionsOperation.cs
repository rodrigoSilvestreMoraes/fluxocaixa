using MongoDB.Bson;
using System.Diagnostics.CodeAnalysis;

namespace FluxoCaixa.Core.Infra.Mongo
{
	[ExcludeFromCodeCoverage]
	public static class FunctionsOperation
	{
		public static bool IsCreateOperationExecuting(ObjectId id) => !id.ToString().Equals("000000000000000000000000");
	}
}
