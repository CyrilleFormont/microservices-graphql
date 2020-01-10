using System;
using System.Collections.Generic;
using System.Text;
using Vanilla.User.Persistence;

namespace Vanilla.User.Application.DAL
{
    public interface IUserRepository : IBaseRepository<Persistence.Models.User, int>
    {
        
    }
    public class UserRepository : RepositoryBase<Persistence.Models.User, int>, IUserRepository
    {
        public UserRepository(UserContext dbContext) : base(dbContext)
        {
        }
    }
}
