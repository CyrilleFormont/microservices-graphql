using Vanilla.Content.Persistence.Enumerators;

namespace Vanilla.Content.Persistence.Models
{
    public class UserAccessContent
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public EUserAccessRight Right { get; set; } 
    }
}
