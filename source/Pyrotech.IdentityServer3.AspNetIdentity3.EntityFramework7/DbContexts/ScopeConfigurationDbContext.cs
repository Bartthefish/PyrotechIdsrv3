using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Entities;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Interfaces;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.DbContexts
{
    public class ScopeConfigurationDbContext : BaseDbContext, IScopeConfigurationDbContext
    {
        private readonly string _schemaName;

        public ScopeConfigurationDbContext(DbContextOptions options, string schemaName = null)
            : base(options)
        {
            _schemaName = schemaName;
        }

        public DbSet<Scope> Scopes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (_schemaName != null)
                modelBuilder.HasDefaultSchema(_schemaName);

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