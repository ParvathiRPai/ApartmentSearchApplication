using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ApartmentSearchWebApp.Services
{
    public class CosmosDbAdapter : ICosmosDbAdapter
    {
        private IKeyVaultAdapter _keyVaultAdapter;
        private ILogger<ICosmosDbAdapter> _logger;
        public CosmosDbAdapter(IKeyVaultAdapter keyVaultAdapter, ILogger<ICosmosDbAdapter> logger)
        {
            _keyVaultAdapter = keyVaultAdapter;
            _logger = logger;
        }

        public async Task<T> GetDocumentAsync<T>(string id, string partitionKey) where T: class
        {
            var cosmosDbConnString = await _keyVaultAdapter.GetSecretAsync("CosmosDbConnectionString");

            try
            {
                var client = new DocumentClient(new Uri("https://apt-test-cdb.documents.azure.com:443/"), cosmosDbConnString);
                var result = await client.ReadDocumentAsync(UriFactory.CreateDocumentUri("AptSearch", "Users", id), new RequestOptions
                {
                    PartitionKey = new PartitionKey(partitionKey),
                });

                return result.Resource as T;
            }
            catch (DocumentClientException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    _logger.LogError(ex, "NotFound");
                }
                else
                {
                    _logger.LogError(ex, "Unknown Exception");
                }

                throw;
            }
        }
    }
}
