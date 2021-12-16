﻿using CrimeLogger.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface INotificationRepository
    {
        public Task<NotificationSubscriptionDTO> AddSubscrition(NotificationSubscriptionDTO subscription);
    }
}
