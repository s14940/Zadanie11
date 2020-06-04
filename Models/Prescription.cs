using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class Prescription
    {
        [Key] public int IdPrescription { get; set; }
        [Required] public DateTime Date { get; set; }
        [Required] public DateTime DueDate { get; set; }

        public int IdDoctor { get; set; }
        public Doctor Doctor { get; set; }

        public int IdPatient { get; set; }
        public Patient Patient { get; set; }

        public PrescriptionMedicament PrescriptionMedicament { get; set; }
    }
}