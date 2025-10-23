namespace AeroclubTimekeeperApi.Mutations
{
    public class CreateAeroplaneInput
    {
        public required string RegistrationCode { get; set; }

        public string? Name { get; set; }

        public string? Type { get; set; }

        public string? Manufacturer { get; set; }

        public int ProductionYear { get; set; }

        public int SeatsNumber { get; set; }

        public int TopSpeed { get; set; }

        public int StallSpeed { get; set; }

        public bool IsServiceRequired { get; set; }

        public double EnginePower { get; set; }
    }
}
