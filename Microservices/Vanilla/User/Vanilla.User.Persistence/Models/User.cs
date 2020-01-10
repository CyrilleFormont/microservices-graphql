using System;
using System.Collections.Generic;
using System.Text;
using Vanilla.User.Persistence.Enumerators;

namespace Vanilla.User.Persistence.Models
{
    public class User : BaseModel,IEntity<int>
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<Bookmark> Bookmarks { get; set; }
        public EUserRole Role { get; set; }
        public EUserStatus Status { get; set; }
    }
}
