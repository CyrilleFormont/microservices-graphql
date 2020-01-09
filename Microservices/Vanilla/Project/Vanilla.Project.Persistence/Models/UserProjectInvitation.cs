using System;
using System.Collections.Generic;
using System.Text;
using Vanilla.Project.Persistence.Enumerators;

namespace Vanilla.Project.Persistence.Models
{
    public class UserProjectInvitation
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int UserId { get; set; }
        public EUserRight UserRight { get; set; }
        public int InvitedByUserId { get; set; }
    }
}
