using CrimeLogger.Shared;

namespace CrimeLogger.Client.Service.IService
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponseDTO> RegisterUser(UserRequestDTO userForRegistration);
        Task<AuthenticationResponseDTO> Login(AuthenticationDTO userForAuthentication);
        Task Logout();

    }
}
