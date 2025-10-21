using AeroclubTimekeeper.Storage.Entities;
using HotChocolate;
using HotChocolate.Types;

namespace AeroclubTimekeeperApi.Subscriptions
{
    public class Subscription
    {
        [Subscribe]
        public CurrentWeather WeatherChanged([EventMessage] CurrentWeather weather) => weather;
    }
}
