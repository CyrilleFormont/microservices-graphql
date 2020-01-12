using System;
using System.Collections.Generic;
using System.Text;

namespace Vanilla.Content.Persistence.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
