using System;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Entities
{
    public class ScopeClaim
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool AlwaysIncludeInIdToken { get; set; }
        public virtual Scope Scope { get; set; }
    }
}