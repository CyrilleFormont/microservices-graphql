using GraphQL.Types;
using Vanilla.User.API.SchemaDefinition.UserDefinition;

namespace Vanilla.User.API.SchemaDefinition
{
    public class Mutations : ObjectGraphType
    {
        public Mutations(UserMutations userMutations)
        {
            this.Field<UserMutations>("userMutations", resolve: ctx => userMutations);
        }
    }
}
