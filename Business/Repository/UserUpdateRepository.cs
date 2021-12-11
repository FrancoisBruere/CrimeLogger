using AutoMapper;
using Business.Repository.IRepository;
using CrimeLogger.Shared;
using DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class UserUpdateRepository : IUserUpdateRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserUpdateRepository(ApplicationDbContext db, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UserUpdateDTO> UpdateUserProfile(UserUpdateDTO userUpdateDTO)
        {

            if (userUpdateDTO != null)
            {
                ApplicationUser userDetails = await _userManager.FindByEmailAsync(userUpdateDTO.Email);
                if (userDetails != null)
                {
                    userDetails.ProvinceId = userUpdateDTO.ProvinceId;
                    userDetails.CityId = userUpdateDTO.CityId;
                    userDetails.SuburbId = userUpdateDTO.SuburbId;
                    userDetails.StreetName = userUpdateDTO.StreetName;
                    userDetails.IsEmailNotification = userUpdateDTO.IsEmailNotification;
                    userDetails.PhoneNumber = userUpdateDTO.PhoneNumber;

                    await _db.SaveChangesAsync();

                    return userUpdateDTO;

                }
               
                
            }
            return null;

        }
    }
}
