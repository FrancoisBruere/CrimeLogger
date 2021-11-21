using CrimeLogger.Client.Service.IService;
using CrimeLogger.Shared;
using Newtonsoft.Json;

namespace CrimeLogger.Client.Service
{
    public class CrimeTypeService : ICrimeTypeService
    {
        private readonly HttpClient _client;

        public CrimeTypeService(HttpClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<CrimeTypeDTO>> GetAllCrimeTypes()
        {
            var responce = await _client.GetAsync($"api/CrimeType/");
            var content = await responce.Content.ReadAsStringAsync();
            var types = JsonConvert.DeserializeObject<IEnumerable<CrimeTypeDTO>>(content);

            return types;
        }
    }
}
