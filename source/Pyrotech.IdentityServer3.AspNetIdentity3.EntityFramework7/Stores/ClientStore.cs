using System;
using System.Threading.Tasks;
using IdentityServer3.Core.Services;
using Microsoft.Data.Entity;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Extensions;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Interfaces;
using Models = IdentityServer3.Core.Models;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Stores
{
    public class ClientStore : IClientStore
    {
        private readonly IClientConfigurationDbContext context;

        public ClientStore(IClientConfigurationDbContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            this.context = context;
        }

        public async Task<Models.Client> FindClientByIdAsync(string clientId)
        {
            var client = await context.Clients
                .Include(x => x.ClientSecrets)
                .Include(x => x.RedirectUris)
                .Include(x => x.PostLogoutRedirectUris)
                .Include(x => x.AllowedScopes)
                .Include(x => x.IdentityProviderRestrictions)
                .Include(x => x.Claims)
                .Include(x => x.AllowedCustomGrantTypes)
                .Include(x => x.AllowedCorsOrigins)
                .SingleOrDefaultAsync(x => x.ClientId == clientId);

            return client.ToModel();
        }
    }
}