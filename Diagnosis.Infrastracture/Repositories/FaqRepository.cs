using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Models.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Infrastracture.Repositories
{
    public class FaqRepository : Repository<Faq> ,IFaq
    {
        private readonly ApplicationDbContext _context;
        public FaqRepository(ApplicationDbContext context) :base(context)
        {
            _context = context;
        }
        public async Task<List<FaqResponseDTO>> GetAllFaqAsync(string? search = null)
        {
            var query = _context.Faqs.AsQueryable();

            if(!string.IsNullOrEmpty(search) )
            {
                query = query.Where(f => f.Question.Contains(search));
            }

            var faqs = await query
                .Select(f => new FaqResponseDTO
                {
                    Question = f.Question,
                })
                .ToListAsync();
            return faqs;
        }
    }
}
