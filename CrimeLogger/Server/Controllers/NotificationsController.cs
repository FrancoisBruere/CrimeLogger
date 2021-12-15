using AutoMapper;
using CrimeLogger.Shared;
using DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CrimeLogger.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public NotificationsController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpPut]
        public async Task<NotificationSubscriptionDTO>Subscribe(NotificationSubscriptionDTO subscription) 
        {
           // var userId =("Samm@sam.com");
            // GetUserId
            //var oldSubscriptions = _db.NotificationSubscriptions.Where(e => e.UserId == userId);
            //_db.NotificationSubscriptions.RemoveRange(oldSubscriptions);

            //subscription.UserId = userId;
            var result = _mapper.Map<NotificationSubscriptionDTO, CrimeNotificationSubscription>(subscription);
            await _db.NotificationSubscriptions.AddAsync(result);

            await _db.SaveChangesAsync();

            return subscription;

        }

    }
}
