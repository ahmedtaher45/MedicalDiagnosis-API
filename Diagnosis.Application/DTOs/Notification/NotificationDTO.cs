using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.Notification
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int? RelatedId { get; set; }
        public string NotificationType { get; set; }
        public bool IsRead { get; set; }

        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }   
}