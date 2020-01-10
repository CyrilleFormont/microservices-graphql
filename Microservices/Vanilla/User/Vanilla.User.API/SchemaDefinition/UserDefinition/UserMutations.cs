using GraphQL.Types;
using MessageBrokerDtos.User;
using MicroserviceCommunicator;
using Vanilla.User.API.SchemaDefinition.UserDefinition.InputTypes;
using Vanilla.User.Application.Services;

namespace Vanilla.User.API.SchemaDefinition.UserDefinition
{
    public class UserMutations : ObjectGraphType
    {
        private readonly IUserServiceMutation _userServiceMutation;
        public UserMutations(IUserServiceMutation userServiceMutation)
        {
            this._userServiceMutation = userServiceMutation;

            this.Field<BooleanGraphType>("registerUser",arguments: new QueryArguments(new QueryArgument<NonNullGraphType<RegisterUserInputType>> { Name = "request" }),resolve: this.RegisterUser);

            this.Field<BooleanGraphType>("removeUser", resolve: this.RemoveUser);
        }


        public object RemoveUser(ResolveFieldContext<object> ctx)
        {
           

            return true;
        }

        public object RegisterUser(ResolveFieldContext<object> ctx)
        {
            var user = ctx.GetArgument<Persistence.Models.User>("request");

            this._userServiceMutation.RegisterUser(ref user);

            return true;
        }
    }
}
