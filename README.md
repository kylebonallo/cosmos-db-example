## Requirements to run locally

This project relies on an Azure Cosmos DB. This can mean using the local Azure Cosmos DB Emulator or a real Cosmos DB in Azure.

1. 
[Option A: To use the local Azure Cosmos DB Emulator] If you haven't already done so, download and install the emulator (https://learn.microsoft.com/en-us/azure/cosmos-db/local-emulator). Run the Emulator locally and the Cosmos DB Emulator explorer will open in a browser tab. From here you can access the URI and primary key of your emulated Cosmos DB required in step 3.

[Option B: To use a real Cosmos DB in Azure] If you haven't already done so, in the Azure Portal create an Azure Cosmos DB (use 'Serverless' to save costs).

2. Open this project in Visual Studio and go to Tools > Package Manager Console window.

3. Create the following environment variables using the URI and Primary Key from your local Cosmos DB Emulator OR Azure Cosmos DB. The project relies on these being created:
- $env:COSMOS_ENDPOINT = "{{YOUR-COSMOS-DB-URI}}"
- $env:COSMOS_KEY = "{{YOUR-COSMOS-DB-PRIMARY-KEY}}"

4. Now run the project in Visual Studio. Go to the Products page and add a new Product, then go to your Cosmos DB Explorer (either local or Azure) and see that the Product has been added to the Container.