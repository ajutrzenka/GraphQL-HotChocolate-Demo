using System;

namespace AeroclubTimekeeper.Storage.Entities
{
    public abstract class Aircraft
    {
        public int Id { get; set; }

        public required string RegistrationCode { get; set; }

        public string? Name { get; set; }

        public string? Type { get; set; }

        public string? Manufacturer { get; set; }

        public int ProductionYear { get; set; }

        public int SeatsNumber { get; set; }

        public int TopSpeed { get; set; }

        public int StallSpeed { get; set; }

        public bool IsServiceRequired { get; set; }

        public bool IsAvailable => !this.IsServiceRequired;

        public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
    }
}
