using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Entities;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Interfaces;
using System;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.DbContexts
{
    public class OperationalDbContext : BaseDbContext, IOperationalDbContext
    {
        private readonly string _schemaName;

        public OperationalDbContext(DbContextOptions options, string schemaName = null)
            : base(options)
        {
            _schemaName = schemaName;
        }

        public OperationalDbContext(IServiceProvider provider, string schemaName = null)
            : base(provider)
        {
            _schemaName = schemaName;
        }

        public OperationalDbContext(IServiceProvider provider, DbContextOptions options,
            string schemaName = null)
            : base(provider, options)
        {
            _schemaName = schemaName;
        }

        public DbSet<Consent> Consents { get; set; }

        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (_schemaName != null)
                modelBuilder.HasDefaultSchema(_schemaName);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Consent>()
                .HasKey(e => new {e.Subject, e.ClientId});
            modelBuilder.Entity<Consent>()
                .ToTable(TableNames.Consent)
                .Property(e => e.Subject).HasMaxLength(200);
            modelBuilder.Entity<Consent>()
                .ToTable(TableNames.Consent)
                .Property(e => e.ClientId).HasMaxLength(200);
            modelBuilder.Entity<Consent>()
                .ToTable(TableNames.Consent)
                .Property(e => e.Scopes).IsRequired().HasMaxLength(2000);

            modelBuilder.Entity<Token>()
                .HasKey(e => new {e.Key, e.TokenType});
            modelBuilder.Entity<Token>()
                .ToTable(TableNames.Token)
                .Property(e => e.SubjectId).HasMaxLength(200);
            modelBuilder.Entity<Token>()
                .Property(e => e.ClientId).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Token>()
                .Property(e => e.JsonCode).IsRequired().HasColumnType("varchar(max)");
            modelBuilder.Entity<Token>()
                .Property(e => e.Expiry).IsRequired();
        }
    }
}