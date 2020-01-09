using GraphQL.Types;
using Vanilla.Project.API.SchemaTypes.UserTypes;

namespace Vanilla.Project.API.SchemaTypes
{
    public class Queries : ObjectGraphType
    {
        public Queries(UserQueries userQueries)
        {
            this.Field<UserQueries>("userQueries", resolve: ctx => userQueries);
        }
    }
}
