using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentSearchWebApp.Services
{
    public class KeyVaultAdapter : IKeyVaultAdapter
    {
        private ILogger<KeyVaultAdapter> _logger;
        public KeyVaultAdapter(ILogger<KeyVaultAdapter> logger)
        {
            _logger = logger;
        }

        public async System.Threading.Tasks.Task<string> GetSecretAsync(string secretName)
        {
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();

            try
            {
                var keyVaultClient = new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));

                var secret = await keyVaultClient.GetSecretAsync("https://apt-test-kv.vault.azure.net/secrets/" + secretName)
                    .ConfigureAwait(false);

                return secret.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError("key vault exception", ex);
                throw;
            }
        }
    }
}
