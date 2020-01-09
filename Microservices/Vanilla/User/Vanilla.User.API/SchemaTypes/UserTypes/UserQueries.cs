using GraphQL.Types;
using Vanilla.User.API.SchemaTypes.UserTypes.Types;

namespace Vanilla.User.API.SchemaTypes.UserTypes
{
    public class UserQueries : ObjectGraphType
    {
        public UserQueries()
        {
            this.Field<UserType>("getUser",
                arguments:
                new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve:
                ctx => new Persistence.Models.User
                {
                    Id = 1
                });
        }
    }
}
