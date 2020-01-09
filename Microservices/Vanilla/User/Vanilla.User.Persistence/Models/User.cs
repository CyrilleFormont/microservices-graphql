using System;
using System.Collections.Generic;
using System.Text;

namespace Vanilla.User.Persistence.Models
{
    public class User : BaseModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<Bookmark> Bookmarks { get; set; }
    }
}
