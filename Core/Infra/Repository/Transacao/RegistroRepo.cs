using FluxoCaixa.Core.Domain.Models.Transacao;
using System.Diagnostics.CodeAnalysis;
using ClientMongo = FluxoCaixa.Core.Infra.Mongo;

namespace FluxoCaixa.Core.Infra.Repository.Transacao
{
	[ExcludeFromCodeCoverage]
	public class RegistroRepo : IRegistroRepo
	{
		readonly ClientMongo.IMongoClient _mongoClient;

		public RegistroRepo(ClientMongo.IMongoClient mongoClient)
		{
			_mongoClient = mongoClient;
		}
		public async Task<RegistroDespesa> CriarDespesa(RegistroDespesa registroDespesa)
		{
			await _mongoClient.GetDataBase().GetCollection<RegistroDespesa>(RegistroDespesa._collectionName).InsertOneAsync(registroDespesa);
			return registroDespesa;
		}

		public async Task<RegistroReceita> CriarReceita(RegistroReceita registroReceita)
		{
			await _mongoClient.GetDataBase().GetCollection<RegistroReceita>(RegistroReceita._collectionName).InsertOneAsync(registroReceita);
			return registroReceita;
		}
	}
}
