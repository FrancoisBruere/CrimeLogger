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
        public async Task<CrimeDetailDTO> CreateCrime(CrimeDetailDTO crimeDetailDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(crimeDetailDTO), Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync($"api/CrimeCreate/", content);
            var apiResponce = await responce.Content.ReadAsStringAsync();
            var crimeSubmitted = JsonConvert.DeserializeObject<CrimeDetailDTO>(apiResponce);
            return crimeSubmitted;
        }

        public async Task<IEnumerable<CrimeDetailDTO>> GetAllCrimeDetails()
        {
            var responce = await _client.GetAsync($"api/CrimeDetail/");
            var content = await responce.Content.ReadAsStringAsync();
            var crimes = JsonConvert.DeserializeObject<IEnumerable<CrimeDetailDTO>>(content);

            return crimes;
        }

        public async Task<IEnumerable<CrimeDetailDTO>> GetCrimeDetailsByTypeId(int typeId)
        {
            var responce = await _client.GetAsync($"api/CrimeDetailByType?typeId={typeId}");

            if (responce.IsSuccessStatusCode)
            {

                var content = await responce.Content.ReadAsStringAsync();
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
