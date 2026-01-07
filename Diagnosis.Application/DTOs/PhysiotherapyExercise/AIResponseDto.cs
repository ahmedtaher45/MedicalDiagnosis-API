using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.PhysiotherapyExercise
{
    public class AIResponseDto
    {
        public string Exercise { get; set; }
        public string Feedback { get; set; }
        public float Error { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
