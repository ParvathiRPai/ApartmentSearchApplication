using System.Collections.Generic;

namespace ApartmentSearchWebApp.Services
{
    public interface ILocationsService
    {
        Location GetLocationByName(string name);
        IList<Location> GetLocations();
    }
}