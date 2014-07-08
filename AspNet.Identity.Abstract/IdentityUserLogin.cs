
namespace AspNet.Identity.Abstract
{
    public class IdentityUserLogin
    {
        public virtual string UserId { get; set; }
        public virtual string LoginProvider { get; set; }
        public virtual string ProviderKey { get; set; }
    }
}
