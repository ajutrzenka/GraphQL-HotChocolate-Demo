namespace AeroclubTimekeeper.Storage.Entities
{
    public class Pilot
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public DateOnly BirthDate { get; set; }

        public required string Email { get; set; }

        public bool HasValidLicense { get; set; }

        public bool IsStudent { get; set; }

        public bool IsInstructor { get; set; }

        public bool HasValidMedicalExamination { get; set; }

        public bool HasInsurance { get; set; }

        public virtual ICollection<Flight> FirstPilotFlights { get; set; } = new List<Flight>();

        public virtual ICollection<Flight> SecondPilotFlights { get; set; } = new List<Flight>();
    }
}
