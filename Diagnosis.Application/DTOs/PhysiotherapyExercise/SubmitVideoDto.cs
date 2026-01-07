using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.PhysiotherapyExercise
{
    public class SubmitVideoDto
    {
        public IFormFile Video { get; set; }
        public string ExerciseName{ get; set; }
    }
}