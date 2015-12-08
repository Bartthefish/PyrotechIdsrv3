using System;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Entities
{
    public class ClientProviderRestriction
    {
        public virtual Guid Id { get; set; }
        public virtual string Provider { get; set; }
        public virtual Client Client { get; set; }
    }
}