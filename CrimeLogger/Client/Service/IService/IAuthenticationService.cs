using CrimeLogger.Shared;

namespace CrimeLogger.Client.Service.IService
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponseDTO> RegisterUser(UserRequestDTO userForRegistration);
        Task<AuthenticationResponseDTO> Login(AuthenticationDTO userForAuthentication);
        Task<ForgotPasswordDTO> ForgotPassword(ForgotPasswordDTO userForReset);
        Task SubscribeToNotifications(NotificationSubscriptionDTO subscription);
        Task Logout();
    
    }
}
