using Diagnosis.Application.DTOs.Inquiry;
using Diagnosis.Application.DTOs.PatientDashboard;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.Services.FileService;
using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Infrastracture.Repositories
{
    public class NotificationRepository: Repository<Notification>, INotificationRepository
    {
        private readonly ApplicationDbContext _context;
       

        public NotificationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        //add notification
       

        public async Task<List<Notification>> GetUserNotificationsAsync(string userId)
        {
            return await _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.Date)
                .ToListAsync();
        }

       public async Task<bool> MarkAllAsReadAsync(string userId) //when user clicks in notification bell----
       {
           var notifications = await _context.Notifications
               .Where(n => n.UserId == userId && !n.IsRead)
               .ToListAsync();

           if (notifications.Count == 0) return false;

           notifications.ForEach(n => n.IsRead = true);
           await _context.SaveChangesAsync();
           return true;
       }
    }
    }
