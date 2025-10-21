using System;

namespace AeroclubTimekeeper.Storage.Entities
{
    public class CurrentWeather
    {
        public int Id { get; set; }

        public int AirportId { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public int WindDirection { get; set; }

        public int WindSpeedKnots { get; set; }

        public virtual Airport? Airport { get; set; }
    }
}
