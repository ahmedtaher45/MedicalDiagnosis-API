using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IAuth Auth { get; }
        IFaq Faq { get; }
        ISupportTicket SupportTicket { get; }
        Task<int> CompleteAsync();
        Task SaveChangesAsync();
    }
}
