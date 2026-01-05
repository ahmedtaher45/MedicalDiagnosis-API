using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.Dashboard
{
    public class PatientListDTO
    {
        public int Id {  get; set; }
        public string PatientName { get; set; }
        public DateTime? LastVisit { get; set; }
        public string Status { get; set; }
        public string Contact { get; set; }
    }
    public class PatientSearchDTO
    {
        public string PatientName { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class PagedResultDTO<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
