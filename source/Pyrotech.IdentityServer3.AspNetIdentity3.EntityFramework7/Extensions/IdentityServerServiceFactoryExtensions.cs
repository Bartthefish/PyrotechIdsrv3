using System;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity.Infrastructure;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Configuration;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.DbContexts;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Interfaces;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Registrations;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Services;
using Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Stores;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Extensions
{
    public static class IdentityServerServiceFactoryExtensions
    {
        public static void RegisterOperationalServices(this IdentityServerServiceFactory factory,
            DbContextOptions options)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            factory.Register(new Registration<IOperationalDbContext>(resolver => new OperationalDbContext(options)));

            factory.AuthorizationCodeStore = new Registration<IAuthorizationCodeStore, AuthorizationCodeStore>();

            factory.TokenHandleStore = new Registration<ITokenHandleStore, TokenHandleStore>();

            factory.ConsentStore = new Registration<IConsentStore, ConsentStore>();

            factory.RefreshTokenStore = new Registration<IRefreshTokenStore, RefreshTokenStore>();
        }

        public static void RegisterConfigurationServices(this IdentityServerServiceFactory factory, DbContextOptions options)
        {
            RegisterClientStore(factory, options);
            RegisterScopeStore(factory, options);
        }

        public static void RegisterClientStore(this IdentityServerServiceFactory factory, DbContextOptions options)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            factory.Register(new Registration<IClientConfigurationDbContext>(resolver => new ClientConfigurationDbContext(options)));
            factory.ClientStore = new Registration<IClientStore, ClientStore>();
            factory.CorsPolicyService = new ClientConfigurationCorsPolicyRegistration(options);
        }

        public static void RegisterScopeStore(this IdentityServerServiceFactory factory, DbContextOptions options)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            factory.Register(new Registration<IScopeConfigurationDbContext>(resolver => new ScopeConfigurationDbContext(options)));
            factory.ScopeStore = new Registration<IScopeStore, ScopeStore>();
        }

        public static void RegisterUserService<TUser>(this IdentityServerServiceFactory factory, UserManager<TUser> userManager, AspNetIdentityOptions options) where TUser : IdentityUser
        {
            factory.UserService = new Registration<IUserService>(resolver => new ApplicationUserService<TUser>(userManager,options));
        }
    }
}