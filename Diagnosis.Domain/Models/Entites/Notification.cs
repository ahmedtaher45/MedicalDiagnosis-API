using Diagnosis.Domain.Models.Entites;
using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
    public enum NotificationType
    {
        Consultation = 1,
        Management = 2,
        System = 3,
        Admin = 4
    }
    public class Notification : BaseEntity
    {
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
        public NotificationType NotificationType { get; set; }
        public bool IsRead { get; set; } = false;
        public int? RelatedId { get; set; }
        public DateTime Date { get; set; }

    }
}
