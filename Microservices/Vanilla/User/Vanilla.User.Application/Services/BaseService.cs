using System;
using System.Collections.Generic;
using System.Text;
using MicroserviceCommunicator;

namespace Vanilla.User.Application.Services
{
    public class BaseService
    {
        protected readonly IMessageBrokerSender mbs;
        public BaseService(IMessageBrokerSender mbs)
        {
            this.mbs = mbs;
        }
    }
}
