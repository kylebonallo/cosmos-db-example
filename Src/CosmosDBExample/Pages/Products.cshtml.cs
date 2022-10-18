using CosmosDBExample.Core.ProductAggregate;
using CosmosDBExample.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CosmosDBExample.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ICosmosDbService _cosmosDbService;
        private readonly ILogger<IndexModel> _logger;

        public List<Product> Products { get; set; } = new List<Product>();

        public ProductsModel(ICosmosDbService cosmosDbService, ILogger<IndexModel> logger)
        {
            _cosmosDbService = cosmosDbService;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            try
            {
                var productFeedResponse = await _cosmosDbService.GetAllItemsInContainerAsync();
                var enumerator = productFeedResponse?.GetEnumerator();

                if (enumerator is not null)
                {
                    while (enumerator.MoveNext())
                    {
                        var product = enumerator.Current;
                        Products.Add(product);
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error: {0}", e.InnerException);
            }
        }

        public async Task<IActionResult> OnPostAsync(string id, string name, string category, int quantity, bool isOnSale = false)
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

            return RedirectToPage("/products");
        }
    }
}
