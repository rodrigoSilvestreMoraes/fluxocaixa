using System.Diagnostics.CodeAnalysis;

namespace FluxoCaixa.Core.Infra.Mongo
{
	[ExcludeFromCodeCoverage]
	public class MongoConfig
	{
		public string User { get; set; }
		public string Password { get; set; }
		public string ConnectionString { get; set; }
		public string DataBaseName { get; set; }
	}
}
