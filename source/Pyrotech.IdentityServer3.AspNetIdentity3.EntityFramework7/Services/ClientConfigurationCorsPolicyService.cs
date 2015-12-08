using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer3.Core.Services;
using Microsoft.Data.Entity;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Extensions;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Interfaces;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Services
{
    public class ClientConfigurationCorsPolicyService : ICorsPolicyService
    {
        readonly IClientConfigurationDbContext _context;

        public ClientConfigurationCorsPolicyService(IClientConfigurationDbContext ctx)
        {
            _context = ctx;
        }

        public async Task<bool> IsOriginAllowedAsync(string origin)
        {
            var urls = await _context.Clients
                .SelectMany(x1 => x1.AllowedCorsOrigins).Select(x => x.Origin).ToArrayAsync();

            return urls.Select(x => x.GetOrigin()).Where(x => x != null).Distinct()
                .Contains(origin, StringComparer.OrdinalIgnoreCase);
        }
    }
}