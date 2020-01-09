using System;
using System.Collections.Generic;
using System.Text;

namespace Vanilla.Project.Persistence.Models
{
   public  class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string IconId { get; set; }
        public List<UserProject> UsersProjects { get; set; }
    }
}
