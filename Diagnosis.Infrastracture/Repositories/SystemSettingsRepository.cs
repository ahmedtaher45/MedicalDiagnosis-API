using Azure.Core;
using Diagnosis.Application.DTOs.SystemSettings;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.Services.EmailService;
using Diagnosis.Domain.Models.Entites;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Request = Diagnosis.Domain.Models.Entites.Request;

namespace Diagnosis.Infrastracture.Repositories
{
    public class SystemSettingsRepository : ISystemSetting
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailsender;

        public SystemSettingsRepository(ApplicationDbContext context , IEmailSender emailsender)
        {
            _context = context;
            _emailsender = emailsender;
        }

        public async Task<List<ContactMessageResponseDTO>> GetContactMessageRequests()
        {
            var requests = await _context.request
                .Select(request => new ContactMessageResponseDTO
                {
                    FullName = request.Name,
                    Email = request.Email,
                    Message = request.Message,
                    Status = RequestStatus.Peding
                })
                .ToListAsync();
            return requests;
        }


        public async Task SendContactMessage(ContactMessageDTO contactMessageDTO)
        {
            var request = new Request
            {
                Name = contactMessageDTO.FullName,
                Email = contactMessageDTO.Email,
                Message = contactMessageDTO.Message,
                
            };
            await _context.AddAsync(request);

            await _context.SaveChangesAsync();
        }
        public async Task ReplyToRequestAsync(SupportRequestDTO requestDTO)
        {
            var request = await _context.request
                .FirstOrDefaultAsync(x => x.Id == requestDTO.RequestId);

            if (request == null)
                throw new Exception("Request not found");

            request.Reply = requestDTO.Reply;
            request.Status = RequestStatus.Replied;

            await _context.SaveChangesAsync();

            var message = new Message(
                new[] { requestDTO.Email },
                "Reply to your request",
                requestDTO.Reply
                );

            await _emailsender.SendEmailAsync(message);
        }

        public async Task<SupportRequestResponseDTO> GetRequestaReplyAsync(int requestID)
        {
            var request = await _context.request
               .FirstOrDefaultAsync(x => x.Id == requestID);

            if (request == null)
                throw new Exception("Request not found");

            return new SupportRequestResponseDTO
            {
                RequestId = requestID,
                Reply = request.Reply,
                Status = request.Status
            };
        }
    }
}
