using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.Azure.Cosmos;

namespace CosmosDBExample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            var cosmosEndpoint = Environment.GetEnvironmentVariable("COSMOS_ENDPOINT");
            var cosmosKey = Environment.GetEnvironmentVariable("COSMOS_KEY");

            using CosmosClient client = new(
                accountEndpoint: cosmosEndpoint!,
                authKeyOrResourceToken: cosmosKey!
            );

            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}