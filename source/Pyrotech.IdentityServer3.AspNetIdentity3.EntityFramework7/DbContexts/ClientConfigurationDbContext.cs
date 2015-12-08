using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Entities;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Interfaces;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.DbContexts
{
    public class ClientConfigurationDbContext : BaseDbContext, IClientConfigurationDbContext
    {
        private readonly string _schemaName;

        public ClientConfigurationDbContext(DbContextOptions options, string schemaName = null) 
            : base(options)
        {
            _schemaName = schemaName;
        }

        public DbSet<Client> Clients { get; set; }

        #region Overrides of DbContext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (_schemaName != null)
                modelBuilder.HasDefaultSchema(_schemaName);

            modelBuilder.Entity<Client>()
                .ToTable(TableNames.Client)
                .HasMany(e => e.ClientSecrets).WithOne(e => e.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Client>()
                .HasMany(e => e.RedirectUris).WithOne(e => e.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Client>()
                .HasMany(e => e.PostLogoutRedirectUris).WithOne(e => e.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Client>()
                .HasMany(e => e.AllowedScopes).WithOne(e => e.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Client>()
                .HasMany(e => e.IdentityProviderRestrictions).WithOne(e => e.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Client>()
                .HasMany(e => e.AllowedCustomGrantTypes).WithOne(e => e.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Client>()
                .HasMany(e => e.ClientSecrets).WithOne(e => e.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Client>()
                .HasMany(e => e.AllowedCorsOrigins).WithOne(e => e.Client).IsRequired().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Client>()
                .HasIndex(e => e.ClientId).IsUnique();
            modelBuilder.Entity<Client>()
                .Property(e => e.ClientId).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Client>()
                .Property(e => e.ClientName).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Client>()
                .Property(e => e.ClientUri).HasMaxLength(2000);
            modelBuilder.Entity<ClientClaim>()
                .ToTable(TableNames.ClientClaim)
                .Property(e => e.Type).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<ClientClaim>()
                .Property(e => e.Value).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<ClientCorsOrigin>()
                .ToTable(TableNames.ClientCorsOrigin)
                .Property(e => e.Origin).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<ClientCustomGrantType>()
                .ToTable(TableNames.ClientCustomGrantType)
                .Property(e => e.GrantType).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<ClientPostLogoutRedirectUri>()
                .ToTable(TableNames.ClientPostLogoutRedirectUri)
                .Property(e => e.Uri).IsRequired().HasMaxLength(2000);
            modelBuilder.Entity<ClientProviderRestriction>()
                .ToTable(TableNames.ClientProviderRestriction)
                .Property(e => e.Provider).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<ClientRedirectUri>()
                .ToTable(TableNames.ClientRedirectUri)
                .Property(e => e.Uri).IsRequired().HasMaxLength(2000);
            modelBuilder.Entity<ClientScope>()
                .ToTable(TableNames.ClientScopes)
                .Property(e => e.Scope).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<ClientSecret>()
                .ToTable(TableNames.ClientSecret)
                .Property(e => e.Value).IsRequired().HasMaxLength(250);
            modelBuilder.Entity<ClientSecret>()
                .Property(e => e.Type).HasMaxLength(250);
            modelBuilder.Entity<ClientSecret>()
                .Property(e => e.Description).HasMaxLength(2000);
        }

        #endregion
    }
}