using CrimeLogger.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IUserUpdateRepository
    {
        public Task<UserUpdateDTO> UpdateUserProfile(UserUpdateDTO userUpdateDTO);
    }
}
