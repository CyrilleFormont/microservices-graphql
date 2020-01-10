using System;
using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;

namespace Vanilla.User.API.SchemaTypes
{
    public class MainSchema: Schema
    {
        public MainSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<Queries>();
            Mutation = provider.GetRequiredService<Mutations>();
        }
    }
}
