﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Vanilla.User.Persistence
{
    public class UserContext : DbContext
    {
        public DbSet<Models.User> Users { get; set; }
    }
}
