using System.Text.Json;
using System.Text.Json.Serialization;

namespace CosmosDBExample.Core.ProductAggregate
{
    public class Product
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("category")]
        public string Category { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
        [JsonPropertyName("isOnSale")]
        public bool IsOnSale { get; set; }
    }
}
