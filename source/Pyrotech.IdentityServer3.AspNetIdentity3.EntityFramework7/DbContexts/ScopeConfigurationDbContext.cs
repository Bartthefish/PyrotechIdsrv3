using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Entities;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Interfaces;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.DbContexts
{
    public class ScopeConfigurationDbContext : BaseDbContext, IScopeConfigurationDbContext
    {
        public ScopeConfigurationDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Scope> Scopes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScopeClaim>()
                .ToTable(TableNames.ScopeClaim)
                .Property(e => e.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<ScopeClaim>()
                .Property(e => e.Description).HasMaxLength(1000);

            modelBuilder.Entity<Scope>()
                .ToTable(TableNames.Scope)
                .HasMany(e => e.ScopeClaims).WithOne(e => e.Scope).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Scope>()
                .Property(e => e.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Scope>()
                .Property(e => e.DisplayName).HasMaxLength(200);
            modelBuilder.Entity<Scope>()
                .Property(e => e.Description).HasMaxLength(1000);
            modelBuilder.Entity<Scope>()
                .Property(e => e.ClaimsRule).HasMaxLength(200);

        }
    }
}