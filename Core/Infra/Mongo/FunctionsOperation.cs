using MongoDB.Bson;

namespace FluxoCaixa.Core.Infra.Mongo
{
	public static class FunctionsOperation
	{
		public static bool IsCreateOperationExecuting(ObjectId id) => !id.ToString().Equals("000000000000000000000000");
	}
}
