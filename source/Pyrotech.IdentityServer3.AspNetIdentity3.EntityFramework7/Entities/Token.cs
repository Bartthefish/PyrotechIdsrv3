using System;
using System.ComponentModel.DataAnnotations;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Entities
{
    public class Token
    {
        public virtual string Key { get; set; }

        public virtual TokenType TokenType { get; set; }

        public virtual string SubjectId { get; set; }

        public virtual string ClientId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public virtual string JsonCode { get; set; }

        public virtual DateTimeOffset Expiry { get; set; }
    }
}