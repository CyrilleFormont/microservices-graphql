using System;
using System.Collections.Generic;
using System.Text;
using Vanilla.Project.Persistence.Enumerators;

namespace Vanilla.Project.Persistence.Models
{
    public class UserProject
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int UserId { get; set; }
        public EUserRight Rights { get; set; }
    }
}
