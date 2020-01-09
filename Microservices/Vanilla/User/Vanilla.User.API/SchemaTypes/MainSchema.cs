using GraphQL;
using GraphQL.Types;

namespace Vanilla.User.API.SchemaTypes
{
    public class MainSchema: Schema
    {
        public MainSchema(IDependencyResolver resolver) : base(resolver)
        {
            this.Query = resolver.Resolve<Queries>();
            this.Mutation = resolver.Resolve<Mutations>();
        }
    }
}
