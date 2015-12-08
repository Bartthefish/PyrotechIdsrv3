using System;
using System.Threading.Tasks;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Entities;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Interfaces;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Stores
{
    public class AuthorizationCodeStore : BaseTokenStore<AuthorizationCode>, IAuthorizationCodeStore
    {
        public AuthorizationCodeStore(IOperationalDbContext context, IScopeStore scopeStore, IClientStore clientStore)
            : base(context, TokenType.AuthorizationCode, scopeStore, clientStore)
        {
        }

        public override async Task StoreAsync(string key, AuthorizationCode code)
        {
            var efCode = new Entities.Token
            {
                Key = key,
                SubjectId = code.SubjectId,
                ClientId = code.ClientId,
                JsonCode = ConvertToJson(code),
                Expiry = DateTimeOffset.UtcNow.AddSeconds(code.Client.AuthorizationCodeLifetime),
                TokenType = this.tokenType
            };

            context.Tokens.Add(efCode);
            await context.SaveChangesAsync();
        }
    }
}
