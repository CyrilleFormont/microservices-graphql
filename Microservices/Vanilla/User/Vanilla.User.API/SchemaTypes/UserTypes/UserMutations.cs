using GraphQL.Types;
using MessageBrokerDtos.User;
using MicroserviceCommunicator;

namespace Vanilla.User.API.SchemaTypes.UserTypes
{
    public class UserMutations : BaseMutation
    {
        public UserMutations(IMessageBrokerSender mbs) : base(mbs)
        {
            this.Field<BooleanGraphType>("registerUser", resolve: this.RegisterUser);
            this.Field<BooleanGraphType>("removeUser", resolve: this.RemoveUser);
        }


        public object RemoveUser(ResolveFieldContext<object> ctx)
        {
            var removedUser = new Persistence.Models.User
            {
                Id = 10,
                Email = "test@test.com.au"
            };

            base.mbs.SendMessage(nameof(RemovedUserEvent), new RemovedUserEvent(removedUser.Id));

            return true;
        }

        public object RegisterUser(ResolveFieldContext<object> ctx)
        {
            var createdUser = new Persistence.Models.User
            {
                Id = 10,
                Email = "test@test.com.au"
            };

            base.mbs.SendMessage(nameof(RegisteredUserEvent),new RegisteredUserEvent(createdUser.Id));

            return true;
        }
    }
}
