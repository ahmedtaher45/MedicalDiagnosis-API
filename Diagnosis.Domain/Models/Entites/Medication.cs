using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
    public enum MedicationRoute
    {
        Oral,
        Injection,
        Topical
    }
    public class Medication: BaseEntity
    {
        public int TreatmentId { get; set; }
        public string DrugName { get; set; }
        public decimal DosageMg { get; set; }
        public string Frequency { get; set; }
        public MedicationRoute Route { get; set; }
        public int PrescribedByDoctorId { get; set; }
        public DateTime PrescribedDate { get; set; }
        public int RefillsLeft { get; set; }
        public string PharmacyNotes { get; set; }
        // Navigation Properties
        public Treatment Treatment { get; set; }
        public Doctor PrescribedByDoctor { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
