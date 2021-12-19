using Business.Repository.IRepository;
using Common;
using CrimeLogger.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
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
        private readonly ICrimeTypeRepository _crimeTypeRepository;
        private readonly IEmailSender _emailSender;

        public CrimeCreateController(ICrimeDetailRepository crimeDetailRepository, INotificationRepository notificationRepository, ICrimeTypeRepository crimeTypeRepository, IEmailSender emailSender)
        {
            _crimeDetailRepository = crimeDetailRepository;
            _notificationRepository = notificationRepository;
            _crimeTypeRepository = crimeTypeRepository;
            _emailSender = emailSender;
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

                    //get and send notifications

                    var pushSubscribers = await _notificationRepository.GetSubscribersToBeNotified(createdCrime);
                    var crimeType =  await _crimeTypeRepository.GetCrimeType(createdCrime.CrimeType_Id.Value);
                   

                    if (pushSubscribers != null)
                    {
                        await SendNotificationAsync(createdCrime, pushSubscribers, $"New crime reported in your area! Details: {crimeType.Name}, {createdCrime.Street}");
                    }

                    var emailSubscribers = await _notificationRepository.GetEmailSubscribersToBeNotified(createdCrime);
                    
                    if (emailSubscribers != null)
                    {
                        await SendEmailNotificationAsync(createdCrime, emailSubscribers);
                    }

                    return StatusCode(201);

                }
                else
                {
                    return StatusCode(500);
                }

        }

        private async Task SendEmailNotificationAsync(CrimeDetailDTO crimeDetail, List<UserDTO> subscriptions)
        {
            var crimeType = await _crimeTypeRepository.GetCrimeType(crimeDetail.CrimeType_Id.Value);

            foreach (var user in subscriptions)
            {
                try
                {
                   await _emailSender.SendEmailAsync(user.Email, "Crimelogger - New crime reported in your area!",
                   $"Crime Details: {crimeType.Name}\n" +
                   $"Street: {crimeDetail.Street}\n" +
                   $"Description: {crimeDetail.Description}\n" +
                   $"Crime date: {crimeDetail.CrimeDate}\n" +
                   $"Reported date: {crimeDetail.CreatedDate}");
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error sending email notification: " + ex.Message);
                }
               
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
                    Console.WriteLine("Error sending push notification: " + ex.Message);
                }
            }
           
        }
    }
}
