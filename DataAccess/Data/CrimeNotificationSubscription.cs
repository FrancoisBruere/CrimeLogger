using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class CrimeNotificationSubscription
    {
        [Key]
        public int NotificationSubscriptionId { get; set; }

        public string UserId { get; set; }

        public string Url { get; set; }

        public string P256dh { get; set; }

        public string Auth { get; set; }
    }
}
