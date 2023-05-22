using FluxoCaixa.Core.Domain.Models.Cliente;
using FluxoCaixa.Core.Domain.Models.Despesa;
using FluxoCaixa.Core.Domain.Models.Fornecedore;
using FluxoCaixa.Core.Domain.Models.Receita;
using FluxoCaixa.Core.Domain.ServiceBusiness.Dominios;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;

using ClientMongo = FluxoCaixa.Core.Infra.Mongo;

namespace FluxoCaixa.Core.Infra.Repository.Dominio
{
    /// <summary>
    /// Usei a Interface da service, por que não vejo necessidade de criar mais interfaces apenas para buscas dados simples.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DominiosRepo : IDominioService
    {
        readonly ClientMongo.IMongoClient _mongoClient;

        public DominiosRepo(ClientMongo.IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public async Task<ClienteView> ConsultarCliente(string id)
            => await _mongoClient.GetDataBase().GetCollection<ClienteView>(ClienteView._collectionName).FindSync(x => x.Id == new ObjectId(id)).FirstOrDefaultAsync();
        public async Task<DespesaView> ConsultarDespesa(string id)
            => await _mongoClient.GetDataBase().GetCollection<DespesaView>(DespesaView._collectionName).FindSync(x => x.Id == new ObjectId(id)).FirstOrDefaultAsync();
        public async Task<FornecedorView> ConsultarFornecedor(string id)
            => await _mongoClient.GetDataBase().GetCollection<FornecedorView>(FornecedorView._collectionName).FindSync(x => x.Id == new ObjectId(id)).FirstOrDefaultAsync();
        public async Task<ReceitaView> ConsultarReceita(string id)
            => await _mongoClient.GetDataBase().GetCollection<ReceitaView>(ReceitaView._collectionName).FindSync(x => x.Id == new ObjectId(id)).FirstOrDefaultAsync();

        public async Task<List<ClienteView>> ListarClientes()
            => await _mongoClient.GetDataBase().GetCollection<ClienteView>(ClienteView._collectionName).FindSync(FilterDefinition<ClienteView>.Empty).ToListAsync();
        public async Task<List<DespesaView>> ListarDespesas()
            => await _mongoClient.GetDataBase().GetCollection<DespesaView>(DespesaView._collectionName).FindSync(FilterDefinition<DespesaView>.Empty).ToListAsync();
        public async Task<List<FornecedorView>> ListarFornecedores()
            => await _mongoClient.GetDataBase().GetCollection<FornecedorView>(FornecedorView._collectionName).FindSync(FilterDefinition<FornecedorView>.Empty).ToListAsync();
        public async Task<List<ReceitaView>> ListarReceitas()
            => await _mongoClient.GetDataBase().GetCollection<ReceitaView>(ReceitaView._collectionName).FindSync(FilterDefinition<ReceitaView>.Empty).ToListAsync();
    }
}
