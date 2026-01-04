using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diagnosis.Application.Interfaces
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<List<Notification>> GetUserNotificationsAsync(string userId);
        Task<bool> MarkAllAsReadAsync(string userId);

    }
}