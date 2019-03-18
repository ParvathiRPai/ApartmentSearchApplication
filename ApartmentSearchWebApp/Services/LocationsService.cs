using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentSearchWebApp.Services
{
    public class Location
    {
        public string Name { get; set; }
        public bool SearchEnabled { get; set; }
    }

    public class LocationsService : ILocationsService
    {
        private IDictionary<string, Location> _locations;
        public LocationsService()
        {
            this._locations = new Dictionary<string, Location>(StringComparer.OrdinalIgnoreCase)
            {
                { "bellevue", new Location {
                        Name = "Bellevue",
                        SearchEnabled = true,
                } },
                { "redmond", new Location {
                        Name = "Redmond",
                        SearchEnabled = true,
                } },
            };
        }

        public IList<Location> GetLocations()
        {
            return _locations.Values.ToList();
        }

        public Location GetLocationByName(string name)
        {
            if(_locations.ContainsKey(name))
            {
                return _locations[name];
            }
            else
            {
                return null;
            }
        }
    }
}
