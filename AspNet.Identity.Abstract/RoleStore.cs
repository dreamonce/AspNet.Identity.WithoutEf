using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Identity.Abstract
{
    public class RoleStore<TRole> : IRoleStore<TRole>,
                                    IQueryableRoleStore<TRole>
                                    where TRole : IdentityRole
    {
        private IRoleRepository<TRole> _repository;
        private bool _disposed;

        public bool ShouldDisposeRepository { get; set; }

        public RoleStore(IRoleRepository<TRole> repository)
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

        public virtual async Task CreateAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }
            _repository.Add(role);
            await Task.FromResult(0);
        }

        public virtual async Task UpdateAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }
            _repository.Update(role);
            await Task.FromResult(0);
        }

        public virtual async Task DeleteAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("user");
            }
            _repository.Delete(role);
            await Task.FromResult(0);
        }

        public virtual async Task<TRole> FindByIdAsync(string roleId)
        {
            ThrowIfDisposed();
            if (string.IsNullOrEmpty(roleId))
            {
                throw new ArgumentNullException("roleId");
            }
            return await Task.FromResult(_repository.FindById(roleId));
        }

        public virtual async Task<TRole> FindByNameAsync(string roleName)
        {
            ThrowIfDisposed();
            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException("roleName");
            }
            return await Task.FromResult(_repository.FindByName(roleName));
        }


        public virtual IQueryable<TRole> Roles
        {
            get
            {
                return _repository.Roles();
            }
        }
    }
}
