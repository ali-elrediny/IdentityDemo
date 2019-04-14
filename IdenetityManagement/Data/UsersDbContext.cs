using System;
using System.Collections.Generic;
using System.Text;
using IdenetityManagement.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdenetityManagement.Data
{
    public class UsersDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {

        public UsersDbContext(DbContextOptions<UsersDbContext> options)
            : base(options)
        {
        }

    }
}
