using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApartmentSearchWebApp.Services
{
    public interface IApartmentService
    {
        Task<IList<Apartment>> GetApartmentsAsync();
    }
}