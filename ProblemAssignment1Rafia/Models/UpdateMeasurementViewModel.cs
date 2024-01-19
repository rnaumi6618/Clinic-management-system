using ProblemAssignment1Rafia.Entities;
namespace ProblemAssignment1Rafia.Models
{
    public class UpdateMeasurementViewModel
    {
        public BPMeasurement? BPMeasurement { get; set; }

        //the list of possible position
        public List<Position>? Positions { get; set; }
    }
}
