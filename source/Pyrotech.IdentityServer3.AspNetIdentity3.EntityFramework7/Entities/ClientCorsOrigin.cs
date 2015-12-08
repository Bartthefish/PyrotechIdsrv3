using System;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Entities
{
    public class ClientCorsOrigin
    {
        public virtual Guid Id { get; set; }
        public virtual string Origin { get; set; }
        public virtual Client Client { get; set; }
    }
}