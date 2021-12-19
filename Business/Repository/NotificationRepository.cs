using AutoMapper;
using Business.Repository.IRepository;
using CrimeLogger.Shared;
using DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;


        public NotificationRepository(ApplicationDbContext db, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;

        }
        public async Task<NotificationSubscriptionDTO> AddSubscrition(NotificationSubscriptionDTO subscription)
        {
            // if needed find old subs and remove

            //var oldSubscriptions = _db.NotificationSubscriptions.Where(e => e.UserId == subscription.UserId);
            //_db.NotificationSubscriptions.RemoveRange(oldSubscriptions);

            if (subscription != null)
            {
                var result = _mapper.Map<NotificationSubscriptionDTO, CrimeNotificationSubscription>(subscription);
                await _db.NotificationSubscriptions.AddAsync(result);

                if (result !=null)
                {
                    await _db.SaveChangesAsync();
                    return subscription;

                }
                throw new NullReferenceException("DB - Addsubscription");
            }
            throw new NullReferenceException("DB - Addsubscription");
           

        }

        public async Task<List<NotificationSubscriptionDTO>> GetSubscribersToBeNotified(CrimeDetailDTO crimeDetail)
        {
            List<NotificationSubscriptionDTO> SendToSubscribers = new List<NotificationSubscriptionDTO>();

            // select from userstable where city province sub etc match and where suscribers match on userid return subscribers

            if (crimeDetail != null)
            {


                var sendToCriteria = await _userManager.Users
                                     .Where(u => u.ProvinceId == crimeDetail.Province_Id)
                                     .Where(u => u.CityId == crimeDetail.City_Id)
                                     .Where(u => u.SuburbId == crimeDetail.Suburb_Id)
                                     .ToListAsync();


                if (sendToCriteria.Any())
                {
                    foreach (var user in sendToCriteria)
                    {
                        var selectedSubscriptions =  _db.NotificationSubscriptions.Where(s => s.UserId == user.Id);

                        foreach (var subscription in selectedSubscriptions)
                        {
                            SendToSubscribers.Add(_mapper.Map<CrimeNotificationSubscription, NotificationSubscriptionDTO>(subscription));
                        }

                       
                    }
                    return SendToSubscribers;

                }


                return null;
            }
            else
            {
                throw new NullReferenceException();
            }

        }

        public async Task<List<UserDTO>> GetEmailSubscribersToBeNotified(CrimeDetailDTO crimeDetail)
        {
            List<UserDTO> SendEmailToSubscribers = new List<UserDTO>();

            if (crimeDetail!=null)
            {
                var sendToCriteria = await _userManager.Users
                .Where(u => u.ProvinceId == crimeDetail.Province_Id)
                .Where(u => u.CityId == crimeDetail.City_Id)
                .Where(u => u.SuburbId == crimeDetail.Suburb_Id)
                .Where(u => u.EmailConfirmed == true)
                .Where(u => u.IsEmailNotification == true)
                .ToListAsync();

                if (sendToCriteria.Any())
                {
                    foreach (var user in sendToCriteria)
                    {
                        try
                        {
                            SendEmailToSubscribers.Add(_mapper.Map<ApplicationUser, UserDTO>(user));
                        }
                        catch (Exception e)
                        {

                            throw new Exception(e.Message);
                        }
                        
                    }
                    return SendEmailToSubscribers;
                }
                return null;
            }
            else
            {
                throw new NullReferenceException();
            }


        }
    }
}
