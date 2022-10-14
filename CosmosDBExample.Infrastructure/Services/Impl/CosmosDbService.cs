using CosmosDBExample.Core.ProductAggregate;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using Container = Microsoft.Azure.Cosmos.Container;

namespace CosmosDBExample.Infrastructure.Services.Impl
{
    public class CosmosDbService : ICosmosDbService
    {
        private CosmosClient _cosmosClient;
        private static string DatabaseId = "companyproducts";
        private readonly ILogger<CosmosDbService> _logger;

        public CosmosDbService(CosmosClient cosmosClient, ILogger<CosmosDbService> logger)
        {
            _cosmosClient = cosmosClient;
            _logger = logger;
        }

        private async Task<Database> GetOrCreateDatabaseAsync()
        {
            // Database reference with creation if it does not already exist
            var cosmosDatabase = await _cosmosClient.CreateDatabaseIfNotExistsAsync(
                id: DatabaseId
            );

            return cosmosDatabase;
        }

        private async Task<Container> GetOrCreateContainerAsync(string containerId, string partitionKeyPath)
        {
            var database = await GetOrCreateDatabaseAsync();

            // Container reference with creation if it does not alredy exist
            Container container = await database.CreateContainerIfNotExistsAsync(
                id: containerId,
                partitionKeyPath: partitionKeyPath,
                throughput: 400
            );

            return container;
        }

        public async Task<Product> GetItemAsync(string id, string partitionKey)
        {
            var container = await GetOrCreateContainerAsync("products", "/category");

            try
            {
                // Point read item from container using the id and partitionKey
                Product product = await container.ReadItemAsync<Product>(
                    id: id,
                    partitionKey: new PartitionKey(partitionKey)
                );

                return product;
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException.Message);
                throw;
            }
        }

        public async Task<Product> CreateProductAsync(Product newProduct)
        {
            var container = await GetOrCreateContainerAsync("products", "/category");

            var createdItem = await container.UpsertItemAsync<Product>(
                item: newProduct,
                partitionKey: new PartitionKey("gear-surf-surfboards"));

            return createdItem;
        }
    }
}
