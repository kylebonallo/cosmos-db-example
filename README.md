## Requirements to run locally

This project relies on an Azure Cosmos DB account.

1. If you haven't already done so, in the Azure Portal create an Azure Cosmos DB (use 'Serverless' to save costs).

2. Open this project in Visual Studio and go to Tools > Package Manager Console window.

3. Create the following environment variables using the URI and Primary Key from the Azure Cosmos account. The project relies on these being created:
- $env:COSMOS_ENDPOINT = "{{YOUR-COSMOS-DB-URI}}"
- $env:COSMOS_KEY = "{{YOUR-COSMOS-DB-PRIMARY-KEY}}"
