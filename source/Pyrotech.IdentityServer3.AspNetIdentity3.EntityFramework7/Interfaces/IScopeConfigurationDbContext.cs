using Microsoft.Data.Entity;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Entities;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Interfaces
{
    public interface IScopeConfigurationDbContext
    {
        DbSet<Scope> Scopes { get; set; }
    }
}