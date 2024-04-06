using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiProdutosMongodb.Models
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("name")]
        public string? Nome { get; set; }
        [BsonElement("value")]
        public double Preco { get; set; }
    }
}
