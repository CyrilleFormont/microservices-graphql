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


    public class UserService : BaseService, IUserServiceMutation, IUserServiceQuery
    {
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow, IMessageBrokerSender mbs) : base(mbs)
        {
            this._uow = uow;
        }

        public Persistence.Models.User GetUser(int userId)
            => this._uow.UserRepository.Get(userId).Result;


        public void RegisterUser(ref Persistence.Models.User user)
        {
            this._uow.UserRepository.Add(user);

            base.mbs.SendMessage(nameof(RegisteredUserEvent), new RegisteredUserEvent(user.Id));
        }
    }
}
