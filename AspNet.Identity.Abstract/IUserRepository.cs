using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AspNet.Identity.Abstract
{
    public interface IUserRepository<TUser, TRole> 
                        where TUser: IdentityUser<TRole>
                        where TRole: IdentityRole
    {
        void Dispose();
        void Add(TUser user);
        void Update(TUser user);
        void Delete(TUser user);
        TUser FindById(string userId);
        TUser FindByName(string userName);
        TUser FindByEmail(string email);
        IQueryable<TUser> Users();
        void AddToRole(TUser user, string roleName);
        void RemoveFromRole(TUser user, string roleName);
        bool IsInRole(TUser user, string roleName);
        IList<string> GetRoles(TUser user);
        void AddClaim(TUser user, Claim claim);
        void RemoveClaim(TUser user, Claim claim);
        IList<Claim> GetClaims(TUser user);
        TUser Find(UserLoginInfo login);
        IList<UserLoginInfo> GetLogins(TUser user);
        void AddLogin(TUser user, UserLoginInfo login);
        void RemoveLogin(TUser user, UserLoginInfo login);  
    }
}
