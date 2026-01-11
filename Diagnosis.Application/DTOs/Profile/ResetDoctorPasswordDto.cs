using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.Profile
{
    public class ResetDoctorPasswordDto
    {
        public string NewPassword { get; set; } = null!;
    }
}