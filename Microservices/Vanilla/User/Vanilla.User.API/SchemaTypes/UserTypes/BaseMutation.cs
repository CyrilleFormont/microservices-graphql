using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using MicroserviceCommunicator;

namespace Vanilla.User.API.SchemaTypes.UserTypes
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
