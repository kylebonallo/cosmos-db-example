using CosmosDBExample.Infrastructure.JsonSerialization;
using CosmosDBExample.Infrastructure.Services;
using CosmosDBExample.Infrastructure.Services.Impl;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CosmosDBExample.Utilities
{
    public static class ServiceCollectionUtilities
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            // Add Cosmos DB
            var cosmosEndpoint = Environment.GetEnvironmentVariable("COSMOS_ENDPOINT");
            var cosmosKey = Environment.GetEnvironmentVariable("COSMOS_KEY");

            // Configure JsonSerializerOptions
            var opt = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            // Configure custom Json serializer
            var serializer = new CosmosSystemTextJsonSerializer(opt);
            // Configure CosmosClientOptions
            var clientOptions = new CosmosClientOptions()
            {
                Serializer = serializer
            };

            var cosmosClient = new CosmosClient(
                accountEndpoint: cosmosEndpoint!,
                authKeyOrResourceToken: cosmosKey!,
                clientOptions: clientOptions
            );

            services.AddSingleton<CosmosClient>(cosmosClient);

            services.AddScoped<ICosmosDbService, CosmosDbService>();

            return services;
        }
    }
}
