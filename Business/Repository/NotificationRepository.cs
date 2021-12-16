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

            //var oldSubscriptions = _db.NotificationSubscriptions.Where(e => e.UserId == userId);
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
    }
}
