using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;

namespace AspNet.Identity.Abstract
{
    public class IdentityUser<TRole>: IUser
                                      where TRole: IdentityRole
    {
        public IdentityUser()
        {
            Id = Guid.NewGuid().ToString();
            Roles = new List<TRole>();
            Claims = new List<IdentityUserClaim>();
            Logins = new List<IdentityUserLogin>();
        }

        public IdentityUser(string userName)
            : this()
        {
            UserName = userName;
        }

        public virtual string Id { get; set; }

        public virtual string UserName { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual string SecurityStamp { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual bool PhoneNumberConfirmed { get; set; }

        public virtual string Email { get; set; }

        public virtual bool EmailConfirmed { get; set; }

        //public virtual DateTimeOffset? LockoutEndDate { get; set; }
        //public virtual bool LockoutEnabled { get; set; }
        //public virtual int AccessFailedCount { get; set; }
        public virtual IList<TRole> Roles { get; protected set; }
        public virtual IList<IdentityUserClaim> Claims { get; protected set; }
        public virtual IList<IdentityUserLogin> Logins { get; protected set; }

    }
}
