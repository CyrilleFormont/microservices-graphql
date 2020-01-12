using System;
using System.Collections.Generic;
using System.Text;

namespace Vanilla.Content.Persistence.Models
{
    public class Project
    {
        public int Id { get; set; }
        public List<Content> Contents { get; set; }
        public List<UserAccessContent> Users { get; set; }
    }
}
