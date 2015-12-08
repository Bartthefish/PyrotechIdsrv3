using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using Microsoft.Data.Entity;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Entities;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Interfaces;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Stores
{
    // TODO: FindAsync is slated to be back in the RTM of 7.0. 
    //      For how, Where and FirstOrDefaultAsync will have to make due
    public class RefreshTokenStore : BaseTokenStore<RefreshToken>, IRefreshTokenStore
    {
        public RefreshTokenStore(IOperationalDbContext context, IScopeStore scopeStore, IClientStore clientStore)
            : base(context, TokenType.RefreshToken, scopeStore, clientStore)
        {
        }

        public override async Task StoreAsync(string key, RefreshToken value)
        {
            var token = await context.Tokens
                .Where(x => x.Key == key && x.TokenType == tokenType)
                .FirstOrDefaultAsync();

            if (token == null)
            {
                token = new Entities.Token
                {
                    Key = key,
                    SubjectId = value.SubjectId,
                    ClientId = value.ClientId,
                    JsonCode = ConvertToJson(value),
                    TokenType = tokenType
                };
                context.Tokens.Add(token);
            }

            token.Expiry = DateTimeOffset.UtcNow.AddSeconds(value.LifeTime);
            await context.SaveChangesAsync();
        }
    }
}