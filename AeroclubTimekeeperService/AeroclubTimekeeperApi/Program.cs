using AeroclubTimekeeper.Storage;
using AeroclubTimekeeperApi.Models;
using AeroclubTimekeeperApi.Mutations;
using AeroclubTimekeeperApi.Queries;
using HotChocolate;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AeroclubTimekeeperService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization()
                .AddDbContextFactory<AeroclubDbContext>(options => AeroclubDbContextFactory.CreateDbContext(options));

            // register graphQL server components
            builder.Services
                .AddGraphQLServer()
                .RegisterDbContextFactory<AeroclubDbContext>()
                .AddType<GliderType>()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddProjections()
                .AddFiltering()
                .AddSorting();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGraphQL();

            app.Run();
        }
    }
}
