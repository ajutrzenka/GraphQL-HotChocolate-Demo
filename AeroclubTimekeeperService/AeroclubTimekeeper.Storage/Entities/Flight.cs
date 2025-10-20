using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroclubTimekeeper.Storage.Entities
{
    public class Flight
    {
        public int Id { get; set; }

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

        public virtual required Airport StartAirport { get; set; }

        public virtual required Airport EndAirport { get; set; }

        public virtual required Aircraft Aircraft { get; set; }

        public virtual required Pilot FirstPilot { get; set; }

        public virtual Pilot? SecondPilot { get; set; }
    }
}
