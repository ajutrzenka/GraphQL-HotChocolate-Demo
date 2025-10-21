using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroclubTimekeeper.Storage.Entities
{
    public interface IAircraft
    {
        int Id { get; set; }

        string RegistrationCode { get; set; }

        string? Name { get; set; }

        string? Type { get; set; }

        string? Manufacturer { get; set; }

        int ProductionYear { get; set; }

        int SeatsNumber { get; set; }

        int TopSpeed { get; set; }

        int StallSpeed { get; set; }

        bool IsServiceRequired { get; set; }

        bool IsAvailable { get; }

        ICollection<Flight> Flights { get; set; }
    }
}
