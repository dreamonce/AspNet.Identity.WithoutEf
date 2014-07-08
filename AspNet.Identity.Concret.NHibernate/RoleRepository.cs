using AspNet.Identity.Abstract;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;

namespace AspNet.Identity.Concret.NHibernate
{
    public class RoleRepository<TRole> : IRoleRepository<TRole>
                                         where TRole : IdentityRole
    {
        private ISession _session;
        public static RoleRepository<TRole> Create(ISession session)
        {
            return new RoleRepository<TRole>(session);
        }
        public RoleRepository(ISession session)
        {
            _session = session;
        }
        public void Dispose()
        {
            _session.Dispose();
        }

        public void Add(TRole role)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Save(role);
                transaction.Commit();
            }
        }
        public void Update(TRole role)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Save(role);
                transaction.Commit();
            }
        }
        public void Delete(TRole role)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Delete(role);
                transaction.Commit();
            }
        }
        public TRole FindById(string roleId)
        {
            return _session.Get<TRole>(roleId);
        }
        public TRole FindByName(string roleName)
        {
            return _session
                .CreateCriteria(typeof(TRole))
                .Add(Restrictions.Eq("Name", roleName))
                .UniqueResult<TRole>();
        }
        public IQueryable<TRole> Roles()
        {
            return _session.CreateCriteria(typeof(TRole)).List<TRole>().AsQueryable();
        }
    }
}
