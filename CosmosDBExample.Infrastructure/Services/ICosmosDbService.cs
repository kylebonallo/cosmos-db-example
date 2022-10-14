using CosmosDBExample.Core.ProductAggregate;

namespace CosmosDBExample.Infrastructure.Services
{
    public interface ICosmosDbService
    {
        Task<Product> GetItemAsync(string id, string partitionKey);
        Task<Product> CreateProductAsync(Product newProduct);
    }
}
