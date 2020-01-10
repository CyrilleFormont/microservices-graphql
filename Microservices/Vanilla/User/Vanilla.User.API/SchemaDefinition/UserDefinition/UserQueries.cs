using GraphQL.Types;
using Vanilla.User.API.SchemaDefinition.UserDefinition.Types;
using Vanilla.User.Application.Services;

namespace Vanilla.User.API.SchemaDefinition.UserDefinition
{
    public class UserQueries : ObjectGraphType
    {
        private readonly IUserServiceQuery _userServiceQuery;
        public UserQueries(IUserServiceQuery userServiceQuery)
        {
            this._userServiceQuery = userServiceQuery;
            this.Field<UserType>("getUser", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}), resolve: this.GetUser);
        }

        public object GetUser(ResolveFieldContext<object> ctx)
        {
            var userId = ctx.GetArgument<int>("id");
            return this._userServiceQuery.GetUser(userId);
        }
    }
}
