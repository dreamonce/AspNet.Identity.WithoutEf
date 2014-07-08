
namespace AspNet.Identity.Abstract
{
    public class IdentityUserClaim
    {
        public virtual string UserId { get; set; }
        public virtual string ClaimType { get; set; }
        public virtual string ClaimValue { get; set; }        
    }
}
