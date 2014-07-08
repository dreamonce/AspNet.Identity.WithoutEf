using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using AspNet.Identity.Abstract;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Reflection;

namespace Eid.MVC.Models
{
    // 可以通过向 ApplicationUser 类添加更多属性来为用户添加配置文件数据。若要了解详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=317594。
    public class ApplicationUser : IdentityUser<ApplicationRole>
    {
        public virtual string RealName { get; set; }

        public virtual string PasswordQuestion { get; set; }

        public virtual string PasswordAnswer { get; set; }

        public virtual async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // 请注意，authenticationType 必须与 CookieAuthenticationOptions.AuthenticationType 中定义的相应项匹配
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在此处添加自定义用户声明
            //manager.AddClaimAsync(Id, new Claim())
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole
    {
        public virtual string Description { get; set; }
    }

    /***
   public class ApplicationDbContext
   {
       private static ISessionFactory _sessionFactory;

       private static ISessionFactory SessionFactory
       {
           get
           {
               if (_sessionFactory == null)
               {
                   _sessionFactory = Fluently.Configure()
                       .Database(OracleDataClientConfiguration.Oracle10.ConnectionString(c => c.FromConnectionStringWithKey("jzdb"))                        )
                       .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                       .BuildSessionFactory();                        
               }
               return _sessionFactory;
           }
       }

       public static IUserRepository<ApplicationUser> Create()
       {
           return SessionFactory.OpenSession();
       }
   }

   

   public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
   {
       public ApplicationDbContext()
           : base("DefaultConnection", throwIfV1Schema: false)
       {
       }

       public static ApplicationDbContext Create()
       {
           return new ApplicationDbContext();
       }
   }
   ***/
}