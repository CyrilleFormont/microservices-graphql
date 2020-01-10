using GraphQL.Types;
using Vanilla.User.API.SchemaDefinition.UserDefinition;

namespace Vanilla.User.API.SchemaDefinition
{
    public class Queries : ObjectGraphType
    {
        public Queries(UserQueries userQueries)
        {
            this.Field<UserQueries>("userQueries", resolve: ctx => userQueries);
        }
    }
}
