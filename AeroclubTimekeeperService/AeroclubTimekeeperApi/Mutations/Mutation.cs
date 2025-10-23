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
            CreateAeroplaneInput input)
        {
            var aeroplane = new Aeroplane()
            {
                RegistrationCode = input.RegistrationCode,
                Name = input.Name,
                ProductionYear = input.ProductionYear,
                SeatsNumber = input.SeatsNumber,
                Manufacturer = input.Manufacturer,
                Type = input.Type,
                TopSpeed = input.TopSpeed,
                StallSpeed = input.StallSpeed,
                EnginePower = input.EnginePower,
                IsServiceRequired = input.IsServiceRequired
            };

            context.Aircrafts.Add(aeroplane);
            await context.SaveChangesAsync();

            return aeroplane;
        }

        public async Task<Flight> CreateFlight(
            AeroclubDbContext context,
            CreateFlightInput input)
        {
            var flight = new Flight()
            {
                AircraftId = input.AircraftId,
                StartAirportId = input.StartAirportId,
                EndAirportId = input.EndAirportId,
                FlightStatus = input.FlightStatus,
                TakeOffTime = input.TakeOffTime,
                LandingTime = input.LandingTime,
                FirstPilotId = input.FirstPilotId,
                SecondPilotId = input.SecondPilotId,
                HasInstructorGroundSupervision = input.HasInstructorGroundSupervision,
                TaskType = input.TaskType
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
