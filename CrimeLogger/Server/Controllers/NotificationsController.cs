using AutoMapper;
using Business.Repository.IRepository;
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

        private readonly INotificationRepository _notification;
        public NotificationsController(INotificationRepository notification)
        {
            _notification = notification;
        }

        [HttpPut]
        public async Task<NotificationSubscriptionDTO>Subscribe(NotificationSubscriptionDTO subscription) 
        {
            var approvedSubscription = await _notification.AddSubscrition(subscription);

            if(approvedSubscription != null)
            {
                return approvedSubscription;
            }
            else
            {
                throw new NullReferenceException("Controller - Addsubscription - Failed");
            }

        }
        
    }
}
