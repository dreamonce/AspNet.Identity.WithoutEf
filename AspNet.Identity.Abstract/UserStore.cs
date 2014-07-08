using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNet.Identity.Abstract
{
    public class UserStore<TUser, TRole> : IUserStore<TUser>,
                                    IUserClaimStore<TUser>,
                                    IUserLoginStore<TUser>,
                                    IUserRoleStore<TUser>,
                                    IUserPasswordStore<TUser>,
                                    IUserSecurityStampStore<TUser>,
                                    IUserPhoneNumberStore<TUser>,
                                    IUserEmailStore<TUser>,
                                    IQueryableUserStore<TUser>,
                                    //IUserLockoutStore<TUser, string>,
                                    IDisposable
                                    where TUser : IdentityUser<TRole> 
                                    where TRole : IdentityRole
    {
        private IUserRepository<TUser, TRole> _repository;
        private bool _disposed;

        public bool ShouldDisposeRepository { get; set; }

        public UserStore(IUserRepository<TUser, TRole> repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");
            ShouldDisposeRepository = true;
            _repository = repository;
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().Name);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _repository != null && ShouldDisposeRepository)
                _repository.Dispose();
            _disposed = true;
            _repository = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual async Task CreateAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
                throw new ArgumentNullException("user");             
            _repository.Add(user);
            await Task.FromResult(0);
        }

        public virtual async Task UpdateAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
                throw new ArgumentNullException("user");
            _repository.Update(user);
            await Task.FromResult(0);
        }

        public virtual async Task DeleteAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
                throw new ArgumentNullException("user");
            _repository.Delete(user);
            await Task.FromResult(0);
        }

        public virtual async Task<TUser> FindByIdAsync(string userId)
        {
            ThrowIfDisposed();
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("userId");
            }
            return await Task.FromResult(_repository.FindById(userId));
        }

        public virtual async Task<TUser> FindByNameAsync(string userName)
        {
            ThrowIfDisposed();
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("userName");
            }
            return await Task.FromResult(_repository.FindByName(userName));
        }

        public virtual async Task<string> GetPasswordHashAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return await Task.FromResult(user.PasswordHash);
        }

        public virtual async Task<bool> HasPasswordAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return await Task.FromResult(user.PasswordHash != null);
        }

        public virtual async Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.PasswordHash = passwordHash;
            await Task.FromResult(0);
        }

        public virtual async Task AddClaimAsync(TUser user, Claim claim)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (claim == null)
            {
                throw new ArgumentNullException("claim");
            }
            _repository.AddClaim(user, claim);
            await Task.FromResult(0);
        }

        public virtual async Task RemoveClaimAsync(TUser user, Claim claim)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (claim == null)
            {
                throw new ArgumentNullException("claim");
            }
            _repository.RemoveClaim(user, claim);
            await Task.FromResult(0);
        }

        public virtual async Task<IList<Claim>> GetClaimsAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return await Task.FromResult(_repository.GetClaims(user));
        }


        public virtual async Task<TUser> FindAsync(UserLoginInfo login)
        {
            this.ThrowIfDisposed();
            if (login == null)
            {
                throw new ArgumentNullException("login");
            }
            return await Task.FromResult(_repository.Find(login));
        }

        public virtual async Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
        {
            ThrowIfDisposed();
            List<UserLoginInfo> userLogins = new List<UserLoginInfo>();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return await Task.FromResult(_repository.GetLogins(user));
        }

        public virtual async Task AddLoginAsync(TUser user, UserLoginInfo login)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (login == null)
            {
                throw new ArgumentNullException("login");
            }
            _repository.AddLogin(user, login);
            await Task.FromResult(0);
        }

        public virtual async Task RemoveLoginAsync(TUser user, UserLoginInfo login)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (login == null)
            {
                throw new ArgumentNullException("login");
            }
            _repository.RemoveLogin(user, login);
            await Task.FromResult(0);
        }

        public virtual async Task AddToRoleAsync(TUser user, string roleName)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentException("roleName");
            }
            _repository.AddToRole(user, roleName);
            await Task.FromResult(0);
        }

        public virtual async Task RemoveFromRoleAsync(TUser user, string roleName)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentException("roleName");
            }
            _repository.RemoveFromRole(user, roleName);
            await Task.FromResult(0);
        }

        public virtual async Task<bool> IsInRoleAsync(TUser user, string roleName)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException("roleName");
            }
            return await Task.FromResult(_repository.IsInRole(user, roleName));
        }

        public virtual async Task<IList<string>> GetRolesAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return await Task.FromResult(_repository.GetRoles(user));
        }

        

        public virtual async Task<string> GetSecurityStampAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return await Task.FromResult(user.SecurityStamp);
        }

        public virtual async Task SetSecurityStampAsync(TUser user, string securityStamp)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.SecurityStamp = securityStamp;
            await Task.FromResult(0);
        }

        public virtual async Task<string> GetPhoneNumberAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return await Task.FromResult(user.PhoneNumber);
        }

        public virtual async Task SetPhoneNumberAsync(TUser user, string phonenumber)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.PhoneNumber = phonenumber;
            _repository.Update(user);
            await Task.FromResult(0);
        }

        public virtual async Task<bool> GetPhoneNumberConfirmedAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return await Task.FromResult(user.PhoneNumberConfirmed);
        }

        public virtual async Task SetPhoneNumberConfirmedAsync(TUser user, bool phonenumberconfirmed)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.PhoneNumberConfirmed = phonenumberconfirmed;
            await Task.FromResult(0);
        }

        public virtual async Task<string> GetEmailAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return await Task.FromResult(user.Email);
        }

        public virtual async Task SetEmailAsync(TUser user, string email)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.Email = email;
            await Task.FromResult(0);
        }

        public virtual async Task<bool> GetEmailConfirmedAsync(TUser user)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return await Task.FromResult(user.EmailConfirmed);
        }
        public virtual async Task SetEmailConfirmedAsync(TUser user, bool emailconfirmed)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.EmailConfirmed = emailconfirmed;
            await Task.FromResult(0);
        }       

        public virtual async Task<TUser> FindByEmailAsync(string email)
        {
            ThrowIfDisposed();
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("email");
            }
            return await Task.FromResult(_repository.FindByEmail(email));
        }

        public virtual IQueryable<TUser> Users
        {
            get
            {
                return _repository.Users();
            }
        }

        //public virtual async Task<bool> GetLockoutEnabledAsync(TUser user)
        //{
        //    ThrowIfDisposed();
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException("user");
        //    }
        //    return await Task.FromResult(user.LockoutEnabled);
        //}
        //public virtual async Task SetLockoutEnabledAsync(TUser user, bool lockoutEnabled)
        //{
        //    ThrowIfDisposed();
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException("user");
        //    }
        //    user.LockoutEnabled = lockoutEnabled;
        //    await Task.FromResult(0);
        //}

        //public virtual async Task<DateTimeOffset> GetLockoutEndDateAsync(TUser user)
        //{
        //    ThrowIfDisposed();
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException("user");
        //    }
        //    return await Task.FromResult(user.LockoutEndDate.Value);
        //}
        //public virtual async Task SetLockoutEndDateAsync(TUser user, DateTimeOffset lockoutEndDate)
        //{
        //    ThrowIfDisposed();
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException("user");
        //    }
        //    user.LockoutEndDate = lockoutEndDate;
        //    await Task.FromResult(0);
        //}

        //public virtual async Task<int> GetAccessFailedCountAsync(TUser user)
        //{
        //    ThrowIfDisposed();
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException("user");
        //    }
        //    return await Task.FromResult(user.AccessFailedCount);
        //}
        //public virtual async Task ResetAccessFailedCountAsync(TUser user)
        //{
        //    ThrowIfDisposed();
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException("user");
        //    }
        //    user.AccessFailedCount = 0;
        //    await Task.FromResult(0);
        //}

        //public virtual async Task<int> IncrementAccessFailedCountAsync(TUser user)
        //{
        //    ThrowIfDisposed();
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException("user");
        //    }
        //    user.AccessFailedCount++;
        //    return await Task.FromResult(user.AccessFailedCount);
        //}
    }
}
