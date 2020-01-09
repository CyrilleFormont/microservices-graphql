using System;
using System.Collections.Generic;
using System.Text;

namespace Vanilla.User.Persistence.Models
{
    public class Credential : BaseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Login { get; set; }
        public string Pasword { get; set; }
    }
}
