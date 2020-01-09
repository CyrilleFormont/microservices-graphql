using GraphQL.Types;
using Vanilla.User.API.SchemaTypes.UserTypes;

namespace Vanilla.User.API.SchemaTypes
{
    public class Queries : ObjectGraphType
    {
        public Queries(UserQueries userQueries)
        {
            this.Field<UserQueries>("userQueries", resolve: ctx => userQueries);
        }
    }
}
