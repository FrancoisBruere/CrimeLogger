using Business.Repository.IRepository;
using Common;
using CrimeLogger.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebPush;

namespace CrimeLogger.Server.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    [Authorize]
    public class CrimeCreateController : Controller
    {
        private readonly ICrimeDetailRepository _crimeDetailRepository;
        private readonly INotificationRepository _notificationRepository;

        public CrimeCreateController(ICrimeDetailRepository crimeDetailRepository, INotificationRepository notificationRepository)
        {
            _crimeDetailRepository = crimeDetailRepository;
            _notificationRepository = notificationRepository;
        }


        [HttpPost]
        public async Task<ActionResult<CrimeDetailDTO>> LogCrime([FromBody] CrimeDetailDTO crimeDetailDTO)
        {
           
                if (crimeDetailDTO == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }
                else
                {
                    var crimeCount = await _crimeDetailRepository.GetCrimeSubmitCount(crimeDetailDTO.CreatedBy);

                    if (crimeCount == SD.SubmissionCount)
                    {
                        return BadRequest("Submit count exceeded");
                    }
                }

                var createdCrime = await _crimeDetailRepository.CreateCrime(crimeDetailDTO);

                if (createdCrime != null)
                {

                    // get users to send notifications too from NotificationRepository
                    // call sendnotifications method
                    var pushSubscribers = await _notificationRepository.GetSubscribersToBeNotified(createdCrime);

                    if (pushSubscribers != null)
                    {
                        await SendNotificationAsync(createdCrime, pushSubscribers, $"New Crime reported in your registered area! Street: {createdCrime.Street}");
                    }
                    
                    return StatusCode(201);

                }
                else
                {
                    return StatusCode(500);
                }

                

        }

      
        private static async Task SendNotificationAsync(CrimeDetailDTO crimeDetail, List<NotificationSubscriptionDTO> subscriptions, string message)
        {
            var publicKey = SD.SubscriptionPublic_key;
            var privateKey = SD.SubscriptionPrivate_key;

            foreach (var subscription in subscriptions)
            {
                var pushSubscription = new PushSubscription(subscription.Url, subscription.P256dh, subscription.Auth);
                var vapidDetails = new VapidDetails("mailto:<francois.bruere@gmail.com>", publicKey, privateKey);
                var webPushClient = new WebPushClient();

                try
                {
                    var payload = JsonSerializer.Serialize(new
                    {
                        message,
                        url = $"crime/detailview",
                    });
                    await webPushClient.SendNotificationAsync(pushSubscription, payload, vapidDetails);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Error sending push notification: " + ex.Message);
                }
            }
           
        }
    }
}
