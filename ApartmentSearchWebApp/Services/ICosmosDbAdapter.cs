using System.Threading.Tasks;

namespace ApartmentSearchWebApp.Services
{
    public interface ICosmosDbAdapter
    {
        Task<T> GetDocumentAsync<T>(string id, string partitionKey) where T : class;
    }
}