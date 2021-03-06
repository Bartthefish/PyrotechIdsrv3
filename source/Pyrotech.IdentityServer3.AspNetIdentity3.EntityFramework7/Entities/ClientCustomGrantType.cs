﻿using System;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Entities
{
    public class ClientCustomGrantType
    {
        public virtual Guid Id { get; set; }
        public virtual string GrantType { get; set; }
        public virtual Client Client { get; set; }
    }
}