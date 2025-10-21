using AeroclubTimekeeper.Storage;
using AeroclubTimekeeperApi.Models;
using AeroclubTimekeeperApi.Mutations;
using AeroclubTimekeeperApi.Queries;
using AeroclubTimekeeperApi.Subscriptions;
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
                .AddSubscriptionType<Subscription>()
                .AddProjections()
                .AddFiltering()
                .AddSorting()
                .AddInMemorySubscriptions();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.MapGraphQL();

            // for subscriptions:
            app.UseRouting();
            app.UseWebSockets();

            app.UseAuthorization();

            /*app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });*/

            app.Run();
        }
    }
}
