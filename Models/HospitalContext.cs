using System;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class HospitalContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }

        public HospitalContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrescriptionMedicament>().HasKey(pm => new {pm.IdMedicament, pm.IdPrescription});

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.PrescriptionMedicament)
                .WithOne(p => p.Prescription)
                .HasForeignKey<PrescriptionMedicament>(pm => pm.IdPrescription);


            modelBuilder.Entity<Patient>().HasData(
                new Patient()
                {
                    IdPatient = 1,
                    FirstName = "Jan",
                    LastName = "Nowak",
                    Birthdate = DateTime.Now,
                },
                new Patient()
                {
                    IdPatient = 2,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Birthdate = DateTime.Now,
                },
                new Patient()
                {
                    IdPatient = 3,
                    FirstName = "Zbigniew",
                    LastName = "Nowak",
                    Birthdate = DateTime.Now,
                }
            );
        }
    }
}