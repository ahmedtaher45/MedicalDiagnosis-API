using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases
{
    public class SupportTicketUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupportTicketUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }        

        public async Task CreateSupportTicketAsync(SupportTicketDTO supportTicketDTO)
        {
            await _unitOfWork.SupportTicket.CreateSupportTicketAsync(supportTicketDTO);
        }
    }
}
