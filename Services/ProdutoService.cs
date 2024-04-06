using ApiProdutosMongodb.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ApiProdutosMongodb.Services
{
    public class ProdutoService
    {
        private readonly IMongoCollection<Produto> _produtosCollection;
        public ProdutoService(IOptions<ProdutoDatabaseSettings> produtoService)
        {
            var mongoClient = new MongoClient(produtoService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(produtoService.Value.DatabaseName);

            _produtosCollection = mongoDatabase.GetCollection<Produto>(produtoService.Value.ProdutoCollectionName);
        }

        public async Task<List<Produto>> GetProdutos()
        {
            return await _produtosCollection.Find(_ => true).ToListAsync();
        }
        public async Task<Produto> GetProduto(string id)
        {
            return await _produtosCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task CreateProduto(Produto newProduto)
        {
            await _produtosCollection.InsertOneAsync(newProduto);
        }
        public async Task UpdateProduto(string id, Produto updatedProduto)
        {
            await _produtosCollection.ReplaceOneAsync(x => x.Id == id, updatedProduto);
        }
        public async Task RemoveAsync(string id)
        {
            await _produtosCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
