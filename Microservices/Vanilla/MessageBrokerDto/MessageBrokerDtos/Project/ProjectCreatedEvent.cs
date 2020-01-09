﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBrokerDtos.Project
{
    public class ProjectCreatedEvent : BaseEvent
    {
        public ProjectCreatedEvent(int projectId,int creatorId)
        {
            this.ProjectId = projectId;
            this.CreatorId = creatorId;
        }
        public int ProjectId { get; set; }
        public int CreatorId { get; set; }
    }
}
