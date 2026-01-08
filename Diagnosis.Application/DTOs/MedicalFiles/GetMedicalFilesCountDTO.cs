using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.MedicalFiles
{
    public class GetMedicalFilesCountDTO
    {
        public int MedicalFilesCount { get; set; }
        public DateTime? LastFileDate { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}