using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentSearchWebApp.Services
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Apartment
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public int Price { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class ApartmentsCosmosDbResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("content")]
        public IDictionary<string, IList<Apartment>> Content { get; set; }
    }

    public class ApartmentService : IApartmentService
    {
        private IList<Apartment> _apartments = new List<Apartment>();
        private ILocationsService _locationsService;
        private ICosmosDbAdapter _cosmosDbAdapter;
        public ApartmentService(ILocationsService locationsService,
            ICosmosDbAdapter cosmosDbAdapter)
        {
            _locationsService = locationsService;
            _cosmosDbAdapter = cosmosDbAdapter;
        }
 
        public async Task<IList<Apartment>> GetApartmentsAsync()
        {
            //will get locations, and query Zillow to get apartments for those locations
            await _cosmosDbAdapter.GetDocumentAsync<ApartmentsCosmosDbResponse>("apartments", "1");
            return _apartments;
        }
    }
}
