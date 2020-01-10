using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vanilla.User.Persistence;

namespace Vanilla.User.Application.DAL
{
    public interface IUserRepository : IBaseRepository<Persistence.Models.User, int>
    {
        Persistence.Models.User GetUserPerEmail(string email);
    }
    public class UserRepository : RepositoryBase<Persistence.Models.User, int>, IUserRepository
    {
        private readonly UserContext _dbContext;
        public UserRepository(UserContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public Persistence.Models.User GetUserPerEmail(string email)
            => this._dbContext.Users.FirstOrDefault(c => string.Equals(c.Email.Trim(), email.Trim(), StringComparison.CurrentCultureIgnoreCase));
    }
}
