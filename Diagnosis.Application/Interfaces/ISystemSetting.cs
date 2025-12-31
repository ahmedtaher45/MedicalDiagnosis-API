using Diagnosis.Application.DTOs.SystemSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.Interfaces
{
    public interface ISystemSetting
    {
        Task SendContactMessage(ContactMessageDTO contactMessageDTO);
        Task<List<ContactMessageResponseDTO>> GetContactMessageRequests();
        Task ReplyToRequestAsync(SupportRequestDTO requestDTO);
        Task<SupportRequestResponseDTO> GetRequestaReplyAsync(int requestID);
    }
}
