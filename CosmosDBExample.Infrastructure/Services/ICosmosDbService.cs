using CosmosDBExample.Core.ProductAggregate;
using CosmosDBExample.Infrastructure.Services.Impl;
using Microsoft.Azure.Cosmos;
using System.ComponentModel;

namespace CosmosDBExample.Infrastructure.Services
{
    public interface ICosmosDbService
    {
        Task<Product> GetItemAsync(string id, string partitionKey);
        Task<FeedResponse<Product>?> GetAllItemsInContainerAsync(string containerId = CosmosDbService.ContainerId, string partitionKeyPath = CosmosDbService.PartitionKeyPath);
        Task<Product> CreateProductAsync(Product newProduct);
    }
}
