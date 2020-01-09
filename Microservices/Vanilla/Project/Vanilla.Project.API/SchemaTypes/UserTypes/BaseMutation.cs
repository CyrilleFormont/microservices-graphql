using GraphQL.Types;
using MicroserviceCommunicator;

namespace Vanilla.Project.API.SchemaTypes.UserTypes
{
    public class BaseMutation : ObjectGraphType
    {
        public readonly IMessageBrokerSender mbs;
        public BaseMutation(IMessageBrokerSender mbs)
        {
            this.mbs = mbs;
        }
    }
}
