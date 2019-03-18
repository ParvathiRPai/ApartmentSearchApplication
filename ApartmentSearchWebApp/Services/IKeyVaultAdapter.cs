using System.Threading.Tasks;

namespace ApartmentSearchWebApp.Services
{
    public interface IKeyVaultAdapter
    {
        Task<string> GetSecretAsync(string secretName);
    }
}