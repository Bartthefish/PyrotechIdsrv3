using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Entities;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Interfaces
{
    public interface IOperationalDbContext : IDisposable
    {
        DbSet<Consent> Consents { get; set; }

        DbSet<Token> Tokens { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}