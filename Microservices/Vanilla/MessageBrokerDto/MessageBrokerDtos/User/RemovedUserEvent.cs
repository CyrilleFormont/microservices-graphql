using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MessageBrokerDtos.User
{
    public class RemovedUserEvent :  BaseEvent,IEvent
    {
        public RemovedUserEvent(int userId)
        {
            this.UserId = userId;
        }
        public  int UserId { get; set; }

        public void Ensure()
        {
            throw new NotImplementedException();
        }
    }
}
