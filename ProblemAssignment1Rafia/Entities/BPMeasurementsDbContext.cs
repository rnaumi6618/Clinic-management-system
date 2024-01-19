
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProblemAssignment1Rafia.Entities
{
   
    public class BPMeasurementsDbContext :DbContext
    {
        // a constructor that calls the base class constructor:
        public BPMeasurementsDbContext(DbContextOptions<BPMeasurementsDbContext> options)
            : base(options) { }

        // Define a property to access the BPMeasurements table in the DB:
        public DbSet<BPMeasurement> BPMeasurements { get; set; }

        public DbSet<Position> Positions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed position:
            modelBuilder.Entity<Position>().HasData(
                new Position() { PositionId="sd", PositionName="Standing"},
                new Position() { PositionId="si", PositionName="Sitting"},
                new Position() { PositionId="ly", PositionName="Lying Down"}
                );
            // Seed some Bpmeasurements:
            modelBuilder.Entity<BPMeasurement>().HasData(
                new BPMeasurement() { BPMeasurementId=1, SystolicValue=190, DiastolicValue=121, PositionId ="sd", DateofReading = new DateTime(2023, 08, 07)},
                new BPMeasurement() { BPMeasurementId=2, SystolicValue=142, DiastolicValue=91, PositionId = "si", DateofReading = new DateTime(2023, 03, 04) },
                new BPMeasurement() {BPMeasurementId =3, SystolicValue =131, DiastolicValue = 85, PositionId = "ly", DateofReading = new DateTime(2023, 07, 03) },
                new BPMeasurement() {BPMeasurementId =4, SystolicValue =122, DiastolicValue = 79, PositionId = "si", DateofReading = new DateTime(2023, 10, 15) },
                new BPMeasurement() {BPMeasurementId =5, SystolicValue = 190, DiastolicValue = 121, PositionId = "ly",  DateofReading = new DateTime(2023, 10, 3) }
                );
        }
    }
}
