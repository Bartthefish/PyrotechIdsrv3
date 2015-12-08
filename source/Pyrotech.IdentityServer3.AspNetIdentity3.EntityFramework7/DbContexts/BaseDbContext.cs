using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.DbContexts
{
    public abstract class BaseDbContext : DbContext
    {
        protected BaseDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}