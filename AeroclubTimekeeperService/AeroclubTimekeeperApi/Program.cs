using AeroclubTimekeeper.Storage;
using AeroclubTimekeeperApi.Mutations;
using AeroclubTimekeeperApi.Queries;
using AeroclubTimekeeperApi.Subscriptions;
using AeroclubTimekeeperApi.Types;
using HotChocolate;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AeroclubTimekeeperApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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

            // for graphQL subscriptions:
            app.UseRouting();
            app.UseWebSockets();

            app.UseAuthorization();

            app.Run();
        }
    }
}
