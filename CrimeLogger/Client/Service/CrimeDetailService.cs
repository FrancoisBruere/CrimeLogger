using CrimeLogger.Shared;
using Newtonsoft.Json;
using System.Text;

namespace CrimeLogger.Client.Service.IService
{
    public class CrimeDetailService : ICrimeDetailService
    {
        private readonly HttpClient _client;

        public CrimeDetailService(HttpClient client)
        {
            _client = client;
        }
        public async Task<HttpResponseMessage> CreateCrime(CrimeDetailDTO crimeDetailDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(crimeDetailDTO), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"api/CrimeCreate/", content);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return response;
            }

            return response;

        }

        public async Task<IEnumerable<CrimeDetailDTO>> GetAllCrimeDetails()
        {
            var response = await _client.GetAsync($"api/CrimeDetail/");
            var content = await response.Content.ReadAsStringAsync();
            var crimes = JsonConvert.DeserializeObject<IEnumerable<CrimeDetailDTO>>(content);

            return crimes;
        }

        public async Task<IEnumerable<CrimeDetailDTO>> GetCrimeDetailsByTypeId(int typeId)
        {
            var response = await _client.GetAsync($"api/CrimeDetailByType?typeId={typeId}");

            if (response.IsSuccessStatusCode)
            {

                var content = await response.Content.ReadAsStringAsync();
                var crimesByType = JsonConvert.DeserializeObject<IEnumerable<CrimeDetailDTO>>(content);
                return crimesByType;

            }
            else
            {
                
                throw new Exception();

            }
        }
    }
}
