using System;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Entities
{
    public class ClientPostLogoutRedirectUri
    {
        public virtual Guid Id { get; set; }
        public virtual string Uri { get; set; }
        public virtual Client Client { get; set; }
    }
}