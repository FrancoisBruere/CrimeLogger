using CrimeLogger.Client.Service.IService;
using CrimeLogger.Shared;
using Newtonsoft.Json;

namespace CrimeLogger.Client.Service
{
    public class CrimeProvinceCitySuburbService : ICrimeProvinceCitySuburbService
    {
        private readonly HttpClient _client;

        public CrimeProvinceCitySuburbService(HttpClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<CrimeProvinceDTO>> GetAllCrimeProvinces()
        {
            var response = await _client.GetAsync("api/CrimeProvince");
            var content = await response.Content.ReadAsStringAsync();
            var provinces = JsonConvert.DeserializeObject<IEnumerable<CrimeProvinceDTO>>(content);

            return provinces;
        }
    }
}
