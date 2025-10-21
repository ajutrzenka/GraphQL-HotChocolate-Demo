using AeroclubTimekeeper.Storage;
using AeroclubTimekeeper.Storage.Entities;
using AeroclubTimekeeperApi.Subscriptions;
using HotChocolate.Subscriptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AeroclubTimekeeperApi.Mutations
{
    public class Mutation
    {
        public async Task<Aeroplane> CreateAeroplane(
            AeroclubDbContext context,
            string registrationCode,
            string name,
            int productionYear,
            string type,
            string manufacturer,
            int seatsNumber, 
            int topSpeed,
            int stallSpeed, 
            double enginePower)
        {
            var aeroplane = new Aeroplane()
            {
                RegistrationCode = registrationCode,
                Name = name,
                ProductionYear = productionYear,
                SeatsNumber = seatsNumber,
                Manufacturer = manufacturer,
                Type = type,
                TopSpeed = topSpeed,
                StallSpeed = stallSpeed,
                EnginePower = enginePower
            };

            context.Aircrafts.Add(aeroplane);
            await context.SaveChangesAsync();

            return aeroplane;
        }

        public async Task<Flight> CreateFlight(
            AeroclubDbContext context,
            int startAirportId,
            int endAirportId,
            FlightStatus flightStatus,
            DateTime? takeOffTime,
            DateTime? landingTime,
            int aircraftId,
            int firstPilotId,
            int? secondPilotId,
            bool hasInstructorGroundSupervision,
            string taskType)
        {
            var flight = new Flight()
            {
                AircraftId = aircraftId,
                StartAirportId = startAirportId,
                EndAirportId = endAirportId,
                FlightStatus = flightStatus,
                TakeOffTime = takeOffTime,
                LandingTime = landingTime,
                FirstPilotId = firstPilotId,
                SecondPilotId = secondPilotId,
                HasInstructorGroundSupervision = hasInstructorGroundSupervision,
                TaskType = taskType
            };

            context.Flights.Add(flight);
            await context.SaveChangesAsync();

            return flight;
        }

        public async Task<Flight> UpdateFlight(
            AeroclubDbContext context,
            int flightId,
            FlightStatus flightStatus,
            DateTime? takeOffTime,
            DateTime? landingTime)
        {
            var flight = await context.Flights.FirstOrDefaultAsync(x => x.Id == flightId);

            if (flight is not null)
            {
                flight.FlightStatus = flightStatus;
                flight.TakeOffTime = takeOffTime;
                flight.LandingTime = landingTime;

                await context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Flight not found.");
            }

            return flight;
        }

        public async Task<DeleteResult> DeleteFlight(
            AeroclubDbContext context,
            int flightId)
        {
            var deletedCount = await context.Flights
                .Where(x => x.Id == flightId)
                .ExecuteDeleteAsync();

            return new DeleteResult
            {
                RecordsCount = deletedCount,
                Success = deletedCount > 0
            };
        }

        public async Task<CurrentWeather> UpdateWeather(
            AeroclubDbContext context,
            int weatherId,
            int temperatureC,
            int windDirection,
            int windSpeed,
            ITopicEventSender sender)
        {
            var weather = await context.CurrentWeathers.FirstOrDefaultAsync(x => x.Id == weatherId);

            if (weather is not null)
            {
                weather.TemperatureC = temperatureC;
                weather.WindDirection = windDirection;
                weather.WindSpeedKnots = windSpeed;

                await context.SaveChangesAsync();

                await sender.SendAsync(nameof(Subscription.WeatherChanged), weather);
            }
            else
            {
                throw new InvalidOperationException("Weather not found.");
            }

            return weather;
        }
    }
}
