using CrimeLogger.Client.Service.IService;
using CrimeLogger.Shared;
using Newtonsoft.Json;
using System.Text;

namespace CrimeLogger.Client.Service
{
    public class UserUpdateService : IUserUpdateService
    {

        private readonly HttpClient _client;

        public UserUpdateService(HttpClient client)
        {
            _client = client;
        }

        public async Task<UserUpdateDTO> GetUserForUpdate(string email)
        {
            var response = await _client.GetAsync($"api/UserDetails/{email}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var userForUpdate = JsonConvert.DeserializeObject<UserUpdateDTO>(content);
                return userForUpdate;
            }
            else
            {

                throw new Exception();

            }
        }

        public async Task<UserUpdateDTO> UpdateUserDetails(UserUpdateDTO userUpdateDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(userUpdateDTO), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"api/UserDetails/", content);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var userUpdateSubmitted = JsonConvert.DeserializeObject<UserUpdateDTO>(apiResponse);
            return userUpdateSubmitted;

        }
    }
}
