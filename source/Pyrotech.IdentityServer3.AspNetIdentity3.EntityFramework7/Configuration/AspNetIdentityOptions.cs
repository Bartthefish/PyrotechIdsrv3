namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Configuration
{
    public class AspNetIdentityOptions
    {
        public string DisplayNameClaimType { get; set; } = "username";

        public bool EnableSecurityStamp { get; set; } = true;
    }
}