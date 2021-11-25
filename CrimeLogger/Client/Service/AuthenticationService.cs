using Blazored.LocalStorage;
using Common;
using CrimeLogger.Client.Service.IService;
using CrimeLogger.Shared;
using CrimeLogger_Client.Service;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CrimeLogger.Client.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthenticationService(HttpClient client, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
        {
            _client = client;
            _localStorage = localStorage;
            _authStateProvider = authStateProvider;
        }

        public async Task<ForgotPasswordDTO> ForgotPassword(ForgotPasswordDTO userForReset)
        {
            var content = JsonConvert.SerializeObject(userForReset);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/account/ForgotPassword", bodyContent);

            if (response.IsSuccessStatusCode)
            {
                return userForReset;
            }
            return null;
        }

        public async Task<AuthenticationResponseDTO> Login(AuthenticationDTO userForAuthentication)
        {
            var content = JsonConvert.SerializeObject(userForAuthentication);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync("api/account/signin", bodyContent);

            var contentTemp = await responce.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AuthenticationResponseDTO>(contentTemp);

            if (responce.IsSuccessStatusCode)
            {
                //user details to local storage
                await _localStorage.SetItemAsync(SD.Local_Token, result.Token);
                await _localStorage.SetItemAsync(SD.Local_UserDetails, result.UserDTO);
                ((AuthStateProvider)_authStateProvider).NotifyUserLoggedIn(result.Token);//convert Authstate and call notifyUSerlogin



                //add bearer token
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);

                //only return that login successful for now
                return new AuthenticationResponseDTO { isAuthSuccessful = true };
            }
            else //if login unsuccessful
            {
                return result;
            }
        }

        public async Task Logout()
        {
            //remove token and user details
            await _localStorage.RemoveItemAsync(SD.Local_Token);
            await _localStorage.RemoveItemAsync(SD.Local_UserDetails);
            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();

            //set auth to null
            _client.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<RegistrationResponseDTO> RegisterUser(UserRequestDTO userForRegistration)
        {
            var content = JsonConvert.SerializeObject(userForRegistration);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync("api/account/signup", bodyContent);


            var contentTemp = await responce.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RegistrationResponseDTO>(contentTemp);


            if (responce.IsSuccessStatusCode)
            {
                return new RegistrationResponseDTO { isRegistrationSuccessful = true };
            }
            else
            {
                return result;
            }
        }
    }
}
