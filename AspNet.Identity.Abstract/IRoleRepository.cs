using System.Linq;

namespace AspNet.Identity.Abstract
{
    public interface IRoleRepository<TRole> where TRole: IdentityRole
    {
        void Dispose();
        void Add(TRole role);
        void Update(TRole role);
        void Delete(TRole role);
        TRole FindById(string roleId);
        TRole FindByName(string roleName);
        IQueryable<TRole> Roles();
    }  
}
