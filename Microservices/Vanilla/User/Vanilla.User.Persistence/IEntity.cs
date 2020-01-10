using System;
using System.Collections.Generic;
using System.Text;

namespace Vanilla.User.Persistence
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
