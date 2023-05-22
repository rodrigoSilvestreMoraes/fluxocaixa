using FluxoCaixa.Core.Domain.Models.Transacao;
using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

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

		public async Task<decimal> TotalSaldoPorPeriodo(DateTime dataInicial, DateTime dataFinal, string collectionName)
		{
			var builder = Builders<RegistroDespesa>.Filter;
			var cultureinfo = new CultureInfo("pt-BR");
			
			var start = new DateTime(dataInicial.Year, dataInicial.Month, dataInicial.Day, 0,0,0);
			var end = new DateTime(dataFinal.Year, dataFinal.Month, dataFinal.Day, 23,59,59);			

			var filter = GetFilter(dataInicial, dataFinal);

			var result = await _mongoClient.GetDataBase()
								.GetCollection<RegistroTransacaoBase>(collectionName)
								.Aggregate()
								.Match(filter)
								.Group(i => i.Status, gr => new { CodigoDespesa = gr.Key, Total = gr.Sum(x => x.Valor) }).ToListAsync();

			return result.Sum(x => x.Total);
		}	

		FilterDefinition<RegistroTransacaoBase> GetFilter(DateTime dataInicial, DateTime dataFinal)
		{
			var builder = Builders<RegistroTransacaoBase>.Filter;
			var cultureinfo = new CultureInfo("pt-BR");

			var start = new DateTime(dataInicial.Year, dataInicial.Month, dataInicial.Day, 0, 0, 0);
			var end = new DateTime(dataFinal.Year, dataFinal.Month, dataFinal.Day, 23, 59, 59);

			var filter = builder.Gte(x => x.DataPagamento, start) &
								builder.Lt(x => x.DataPagamento, end);

			return filter;
		}
	}
}
