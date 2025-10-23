using AeroclubTimekeeper.Storage.Entities;
using System;

namespace AeroclubTimekeeperApi.Mutations
{
    public class CreateFlightInput
    {
        public int StartAirportId { get; set; }

        public int EndAirportId { get; set; }

        public FlightStatus FlightStatus { get; set; }

        public DateTime? TakeOffTime { get; set; }

        public DateTime? LandingTime { get; set; }

        public int AircraftId { get; set; }

        public int FirstPilotId { get; set; }

        public int? SecondPilotId { get; set; }

        public bool HasInstructorGroundSupervision { get; set; }

        public required string TaskType { get; set; }
    }
}
