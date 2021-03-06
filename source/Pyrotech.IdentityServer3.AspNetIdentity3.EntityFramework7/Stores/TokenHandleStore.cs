﻿using System;
using System.Threading.Tasks;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Interfaces;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Stores
{
    public class TokenHandleStore : BaseTokenStore<Token>, ITokenHandleStore
    {
        public TokenHandleStore(IOperationalDbContext context, IScopeStore scopeStore, IClientStore clientStore)
            : base(context, Entities.TokenType.TokenHandle, scopeStore, clientStore)
        {
        }

        public override async Task StoreAsync(string key, Token value)
        {
            var efToken = new Entities.Token
            {
                Key = key,
                SubjectId = value.SubjectId,
                ClientId = value.ClientId,
                JsonCode = ConvertToJson(value),
                Expiry = DateTimeOffset.UtcNow.AddSeconds(value.Lifetime),
                TokenType = this.tokenType
            };

            context.Tokens.Add(efToken);
            await context.SaveChangesAsync();
        }
    }
}