using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Vanilla.User.Application.DAL
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
    public class UnitOfWork
    {
        private readonly IServiceProvider _serviceProvider;
        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

        }
        public IUserRepository UserRepository => _serviceProvider.GetService<IUserRepository>();
    }
}
