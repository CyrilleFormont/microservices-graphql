using GraphQL.Types;
using Vanilla.User.API.SchemaTypes.UserTypes;

namespace Vanilla.User.API.SchemaTypes
{
    public class Mutations : ObjectGraphType
    {
        public Mutations(UserMutations userMutations)
        {
            this.Field<UserMutations>("userMutations", resolve: ctx => userMutations);
        }
    }
}
