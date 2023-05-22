using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace FluxoCaixa.Core.Domain.Models
{
	public class FlatData
	{
		[JsonIgnore]
		public ObjectId Id { get; set; }
		public string Codigo
		{
			get
			{
				return Id.ToString();
			}
		}
		public string Nome { get; set; }
	}
}
