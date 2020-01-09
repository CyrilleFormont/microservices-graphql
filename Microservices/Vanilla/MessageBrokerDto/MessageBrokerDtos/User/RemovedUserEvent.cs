using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MessageBrokerDtos.User
{
    public class RemovedUserEvent :  BaseEvent
    {
        public RemovedUserEvent(int userId)
        {
            this.UserId = userId;
        }
        public  int UserId { get; set; }
    }
}
