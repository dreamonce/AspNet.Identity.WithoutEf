using AspNet.Identity.Abstract;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace AspNet.Identity.Concret.NHibernate
{
    public class UserRepository<TUser, TRole>: IUserRepository<TUser, TRole>, 
                                        IDisposable
                                        where TUser : IdentityUser<TRole>
                                        where TRole : IdentityRole
    {
        private ISession _session;
        public static UserRepository<TUser, TRole> Create(ISession session)
        {
            return new UserRepository<TUser, TRole>(session);
        }
        public UserRepository(ISession session)
        {
            _session = session;
        }
        public void Dispose()
        {
            _session.Dispose();
        }
        public void Add(TUser user)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {                
                _session.Save(user);
                transaction.Commit();
            }
        }
        public void Update(TUser user)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Save(user);
                transaction.Commit();
            }
        }
        public void Delete(TUser user)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Delete(user);
                transaction.Commit();
            }
        }

        public TUser FindById(string userId)
        {
            return _session.Get<TUser>(userId);
        }

        public TUser FindByName(string userName)
        {
            return _session
                    .CreateCriteria(typeof(TUser))
                    .Add(Restrictions.Eq("UserName", userName))
                    .UniqueResult<TUser>();
        }

        public TUser FindByEmail(string email)
        {
            return _session
                    .CreateCriteria(typeof(TUser))
                    .Add(Restrictions.Eq("Email", email))
                    .UniqueResult<TUser>();
        }
        public IQueryable<TUser> Users()
        {
            return _session.CreateCriteria(typeof(TUser)).List<TUser>().AsQueryable();
        }


        public void AddToRole(TUser user, string roleName)
        {
            TRole role = _session
                            .CreateCriteria(typeof(TRole))
                            .Add(Restrictions.Eq("Name", roleName))
                            .UniqueResult<TRole>();
            user.Roles.Add(role);
            _session.Save(user);
        }

        public void RemoveFromRole(TUser user, string roleName)
        {
            TRole role = _session
                            .CreateCriteria(typeof(TRole))
                            .Add(Restrictions.Eq("Name", roleName))
                            .UniqueResult<TRole>();
            user.Roles.Remove(role);
            _session.Save(user);
        }

        public bool IsInRole(TUser user, string roleName)
        {
            return user.Roles.Select(m => m.Name).ToList().IndexOf(roleName) >= 0;
        }

        public IList<string> GetRoles(TUser user)
        {
            return user.Roles.Select(m => m.Name).ToList();
        }

        public void AddClaim(TUser user, Claim claim)
        {
            user.Claims.Add(new IdentityUserClaim()
            {
                UserId = user.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            });
            _session.Save(user);
        }
        public void RemoveClaim(TUser user, Claim claim)
        {
            user.Claims.Remove(new IdentityUserClaim()
            {
                UserId = user.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            });
            _session.Save(user);
        }
        public IList<Claim> GetClaims(TUser user)
        {
            return user.Claims.Select(m => new Claim(m.ClaimType, m.ClaimValue)).ToList();
        }
        public TUser Find(UserLoginInfo login)
        {
            var query = from u in _session.QueryOver<TUser>().List()
                        from l in u.Logins
                        where l.LoginProvider == login.LoginProvider && l.ProviderKey == login.ProviderKey
                        select u;
            return query.SingleOrDefault();
        }
        public IList<UserLoginInfo> GetLogins(TUser user)
        {
            return user.Logins.Select(m => new UserLoginInfo(m.LoginProvider, m.ProviderKey)).ToList();
        }
        public void AddLogin(TUser user, UserLoginInfo login)
        {
            user.Logins.Add(new IdentityUserLogin()
                {
                    LoginProvider = login.LoginProvider,
                    ProviderKey = login.ProviderKey
                });
            _session.Save(user);
        }
        public void RemoveLogin(TUser user, UserLoginInfo login)
        {
            user.Logins.Remove(new IdentityUserLogin()
            {
                LoginProvider = login.LoginProvider,
                ProviderKey = login.ProviderKey
            });
            _session.Save(user);
        }
    }
}
