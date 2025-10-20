using AeroclubTimekeeper.Storage.Entities;
using HotChocolate.Types;
using System.ComponentModel.DataAnnotations;

namespace AeroclubTimekeeperApi.Models
{
    public class GliderType : ObjectType<Glider>
    {
        protected override void Configure(IObjectTypeDescriptor<Glider> descriptor)
        {
            descriptor.Field(d => d.Name).Type<StringType>().Description("Nazwa szybowca");
        }
    }
}
