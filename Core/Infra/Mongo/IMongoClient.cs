using MongoDB.Driver;

namespace FluxoCaixa.Core.Infra.Mongo
{
	public interface IMongoClient
	{
		IMongoDatabase GetDataBase();
	}
}
