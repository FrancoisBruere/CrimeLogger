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

        public async Task<IEnumerable<CrimeCityDTO>> GetAllCrimeCities()
        {
            var responce = await _client.GetAsync($"api/AllCrimeCities/");
            var content = await responce.Content.ReadAsStringAsync();
            var cities = JsonConvert.DeserializeObject<IEnumerable<CrimeCityDTO>>(content);

            return cities;
        }
    

        public async Task<IEnumerable<CrimeProvinceDTO>> GetAllCrimeProvinces()
        {
            var response = await _client.GetAsync("api/CrimeProvince");
            var content = await response.Content.ReadAsStringAsync();
            var provinces = JsonConvert.DeserializeObject<IEnumerable<CrimeProvinceDTO>>(content);

            return provinces;
        }

        public async Task<IEnumerable<CrimeSuburbDTO>> GetAllCrimeSuburbs()
        {
            var responce = await _client.GetAsync($"api/AllCrimeSuburbs/");
            var content = await responce.Content.ReadAsStringAsync();
            var suburbs = JsonConvert.DeserializeObject<IEnumerable<CrimeSuburbDTO>>(content);

            return suburbs;
        }

        public async Task<IEnumerable<CrimeCityDTO>> GetCityDetailsByProvinceId(int provinceId)
        {
            var responce = await _client.GetAsync($"api/CrimeCity?provinceId={provinceId}");
            try
            {
                if (responce.IsSuccessStatusCode)
                {

                    var content = await responce.Content.ReadAsStringAsync();
                    var cities = JsonConvert.DeserializeObject<IEnumerable<CrimeCityDTO>>(content);
                    return cities;
                }
                else
                {
                    
                    throw new Exception();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<CrimeSuburbDTO>> GetSuburbDetailsByCityId(int cityId)
        {
            var responce = await _client.GetAsync($"api/CrimeSuburb?cityId={cityId}");

            if (responce.IsSuccessStatusCode)
            {

                var content = await responce.Content.ReadAsStringAsync();
                var suburbs = JsonConvert.DeserializeObject<IEnumerable<CrimeSuburbDTO>>(content);
                return suburbs;

            }
            else
            {
                throw new Exception();
            }
        }
    }
}
