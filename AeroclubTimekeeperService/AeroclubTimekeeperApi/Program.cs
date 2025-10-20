using AeroclubTimekeeper.Storage;
using AeroclubTimekeeperApi.Models;
using AeroclubTimekeeperApi.Queries;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AeroclubTimekeeperService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization()
                .AddDbContextFactory<AeroclubDbContext>(options => AeroclubDbContextFactory.CreateDbContext(options))
                .AddGraphQLServer()
                .RegisterDbContextFactory<AeroclubDbContext>()
                .AddType<GliderType>()
                .AddQueryType<Query>();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGraphQL();

            app.Run();
        }
    }
}
