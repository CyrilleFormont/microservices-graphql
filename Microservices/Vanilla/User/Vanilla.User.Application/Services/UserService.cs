using System;
using MessageBrokerDtos.User;
using MicroserviceCommunicator;
using Vanilla.User.Application.DAL;

namespace Vanilla.User.Application.Services
{
    public interface IUserServiceMutation
    {
        void RegisterUser(ref Persistence.Models.User user);
    }

    public interface IUserServiceQuery
    {
        Persistence.Models.User GetUser(int userId);
    }


    public class UserService : BaseService, IUserServiceQuery, IUserServiceMutation
    {
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow, IMessageBrokerSender mbs) : base(mbs)
        {
            this._uow = uow;
        }

        /// <summary>
        /// Get an user based on his id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Persistence.Models.User GetUser(int userId)
            => this._uow.UserRepository.Get(userId).Result;

        /// <summary>
        /// Register an user
        /// </summary>
        /// <param name="user">user that must be registered</param>
        public void RegisterUser(ref Persistence.Models.User user)
        {
            if (this._uow.UserRepository.GetUserPerEmail(user.Email) != null)
                throw new InvalidOperationException($"Email already used.");

            this._uow.UserRepository.Add(user);

            base.mbs.SendMessage(nameof(RegisteredUserEvent), new RegisteredUserEvent(user.Id));
        }
    }
}
