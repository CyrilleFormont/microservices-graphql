using System;
using System.Collections.Generic;
using System.Text;

namespace Vanilla.User.Persistence.Models
{
    public class Bookmark : BaseModel
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
