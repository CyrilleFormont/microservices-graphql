using System;
using System.Collections.Generic;
using System.Text;

namespace Vanilla.User.Persistence.Models
{
    public class Address  : BaseModel
    {
        public int Id { get; set; }
        public int UnitNumber { get; set; }
        public int Number { get; set; }
        public string StreetName { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
