using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBrokerDtos.User
{
    public class RegisteredUserEvent : BaseEvent, IEvent
    {
        public RegisteredUserEvent(int userId)
        {
            this.UserId = userId;
        }
        public int UserId { get; set; }

        public void Ensure()
        {
            throw new NotImplementedException();
        }
    }
}
