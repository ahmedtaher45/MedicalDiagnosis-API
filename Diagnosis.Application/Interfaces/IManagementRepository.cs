using Diagnosis.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.Interfaces
{
    public interface IManagementRepository:IRepository<Doctor>
    {
        Task<Doctor> GetByIdAsync(int id);
        Task<List<Doctor>> GetAllAsync();
        Task AddAsync(Doctor entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
