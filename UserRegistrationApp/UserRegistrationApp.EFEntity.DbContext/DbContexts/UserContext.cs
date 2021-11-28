using Microsoft.EntityFrameworkCore;
using UserRegistrationApp.EFEntity.Models;

namespace UserRegistrationApp.EFEntity.DbContext.DbContexts
{
    public sealed class UserContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            Database?.EnsureCreated();
        }
    }
}
