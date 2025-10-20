using AeroclubTimekeeper.Storage;
using AeroclubTimekeeper.Storage.Entities;
using AeroclubTimekeeperApi.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;

namespace AeroclubTimekeeperApi.Queries
{
    //[QueryType]
    public class Query
    {
        public Glider GetGlider(int id) =>
            new Glider
            {
                Id = 1,
                RegistrationCode = "SP-3550",
                Name = "Puchatek",
                Type = "Szybowiec szkoleniowy",
                OptimalSpeed = 85,
                StallSpeed = 60,
                TopSpeed = 200,
                LiftToDragRatio = 27,
                ProductionYear = 1985,
                SeatsNumber = 2,
                IsServiceRequired = false,
            } ??
        throw new GraphQLException("Aircraft not found.");

        public List<Glider> GetGliders(AeroclubDbContext context) => new List<Glider>
        {
            new Glider
            {
                Id = 1,
                RegistrationCode = "SP-3550",
                Name = "Puchatek",
                Type = "Szybowiec szkoleniowy",
                OptimalSpeed = 85,
                StallSpeed = 60,
                TopSpeed = 200,
                LiftToDragRatio = 27,
                ProductionYear = 1985,
                SeatsNumber = 2,
                IsServiceRequired = false,
            }
        };

        public List<Aeroplane> GetAeroplanes() => new List<Aeroplane>
        {
            new Aeroplane
            {
                Id = 1,
                RegistrationCode = "SP-KBK",
                Name = "Cessna 172",
                Type = "Awionetka",
                EnginePower = 200,
                StallSpeed = 60,
                TopSpeed = 275,
                ProductionYear = 1985,
                SeatsNumber = 4,
                IsServiceRequired = false,
            }
        };

        public List<Pilot> GetPilots() => new List<Pilot>();

        public List<Pilot> GetFlights() => new List<Pilot>();
    }
}
