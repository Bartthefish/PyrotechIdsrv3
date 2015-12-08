using System;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Microsoft.Data.Entity.Infrastructure;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.DbContexts;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Services;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Registrations
{
    public class ClientConfigurationCorsPolicyRegistration :
        Registration<ICorsPolicyService, ClientConfigurationCorsPolicyService>
    {
        public ClientConfigurationCorsPolicyRegistration(DbContextOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            AdditionalRegistrations.Add(new Registration<ClientConfigurationDbContext>(resolver =>
                new ClientConfigurationDbContext(options)));
        }
    }
}