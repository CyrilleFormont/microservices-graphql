using System;
using GraphQL.Types;
using GraphQL.Utilities;

namespace Vanilla.User.API.SchemaDefinition
{
    public class MainSchema: Schema
    {
        public MainSchema(IServiceProvider provider) : base(provider)
        {
            this.Query = provider.GetRequiredService<Queries>();
            this.Mutation = provider.GetRequiredService<Mutations>();
        }
    }
}
