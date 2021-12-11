using CrimeLogger.Shared;

namespace CrimeLogger.Client.Service.IService
{
    public interface IUserUpdateService
    {
        public Task<UserUpdateDTO> UpdateUserDetails(UserUpdateDTO userUpdateDTO);

        public Task<UserUpdateDTO> GetUserForUpdate(string email);
    }
}
