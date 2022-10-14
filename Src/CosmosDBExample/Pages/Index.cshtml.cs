using CosmosDBExample.Core.ProductAggregate;
using CosmosDBExample.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.Azure.Cosmos;

namespace CosmosDBExample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICosmosDbService _cosmosDbService;
        private readonly ILogger<IndexModel> _logger;

        public Product? Product { get; set; }

        public IndexModel(ICosmosDbService cosmosDbService, ILogger<IndexModel> logger)
        {
            _cosmosDbService = cosmosDbService;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            var productId = "68719518391";
            var productCategory = "gear-surf-surfboards";

            try
            {
                Product = await _cosmosDbService.GetItemAsync(productId, productCategory);
            }
            catch (Exception e)
            {

            }
        }

        public async Task OnPostAsync(string id, string name, string category, int quantity, bool isOnSale = false)
        {
            var newProduct = new Product()
            {
                Id = id,
                Category = category,
                Name = name,
                Quantity = quantity,
                IsOnSale = false
            };

            await _cosmosDbService.CreateProductAsync(newProduct);
        }
    }
}