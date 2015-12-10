using System;
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

        protected BaseDbContext(IServiceProvider provider)
            : base(provider)
        {
        }

        protected BaseDbContext(IServiceProvider provider, DbContextOptions options)
            : base(provider,options)
        {
        }
    }
}