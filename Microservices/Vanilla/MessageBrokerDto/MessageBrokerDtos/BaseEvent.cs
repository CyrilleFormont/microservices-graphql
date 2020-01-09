using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBrokerDtos
{
    public class BaseEvent 
    {
        public BaseEvent()
        {
            this.EventDateTime=DateTime.Now;
        }

        public DateTime EventDateTime { get;  }
    }
}
