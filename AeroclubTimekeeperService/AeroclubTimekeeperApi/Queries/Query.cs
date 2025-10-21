using AeroclubTimekeeper.Storage;
using AeroclubTimekeeper.Storage.Entities;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroclubTimekeeperApi.Queries
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<IAircraft> GetAircrafts(AeroclubDbContext context)
        {
            return context.Aircrafts.Include(x => x.Flights);
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Glider> GetGliders(AeroclubDbContext context)
        {
            return context.Aircrafts.Include(x => x.Flights)
                .Where(x => x is Glider).Cast<Glider>();
        }

        [UseProjection]
        public async Task<Glider?> GetGlider(AeroclubDbContext context, int id)
        {
            return await context.Aircrafts.Include(x => x.Flights)
                .Where(x => x is Glider && x.Id == id)
                .Cast<Glider>().FirstOrDefaultAsync()
            ?? throw new GraphQLException("Glider not found.");
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Aeroplane> GetAeroplanes(AeroclubDbContext context)
        {
            return context.Aircrafts.Include(x => x.Flights)
                .Where(x => x is Aeroplane).Cast<Aeroplane>();
        }

        [UseProjection]
        public async Task<Aeroplane?> GetAeroplane(AeroclubDbContext context, int id)
        {
            return await context.Aircrafts.Where(x => x is Aeroplane && x.Id == id)
                .Cast<Aeroplane>().FirstOrDefaultAsync()
            ?? throw new GraphQLException("Aeroplane not found.");
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Pilot> GetPilots(AeroclubDbContext context)
        {
            return context.Pilots
                .Include(x => x.FirstPilotFlights)
                    .ThenInclude(y => y.Aircraft)
                .Include(x => x.FirstPilotFlights)
                    .ThenInclude(y => y.StartAirport)
                .Include(x => x.FirstPilotFlights)
                    .ThenInclude(y => y.EndAirport)
                .Include(x => x.SecondPilotFlights)
                    .ThenInclude(y => y.Aircraft)
                .Include(x => x.SecondPilotFlights)
                    .ThenInclude(y => y.StartAirport)
                .Include(x => x.SecondPilotFlights)
                    .ThenInclude(y => y.EndAirport);
        }

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Flight> GetFlights(AeroclubDbContext context)
        {
            return context.Flights.Include(x => x.Aircraft)
                .Include(x => x.StartAirport)
                .Include(x => x.EndAirport);
        }
    }
}
