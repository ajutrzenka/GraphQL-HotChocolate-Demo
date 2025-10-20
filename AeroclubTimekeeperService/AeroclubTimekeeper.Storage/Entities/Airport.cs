using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroclubTimekeeper.Storage.Entities
{
    public class Airport
    {
        public int Id { get; set; }

        public required string Code { get; set; }

        public string? Name { get; set; }

        public virtual CurrentWeather? Weather { get; set; }
    }
}
