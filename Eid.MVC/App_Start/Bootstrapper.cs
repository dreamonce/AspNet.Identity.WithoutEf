using AspNet.Identity.Abstract;
using AspNet.Identity.Concret.NHibernate;
using Autofac;
using Autofac.Integration.Mvc;
using Eid.MVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Eid.MVC.App_Start
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            //AutoMapperConfiguration.Configure();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            //注册模型绑定
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();
            //注册控制器
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //注册
            //builder.RegisterType<UserRepository<ApplicationUser>>().As<I>();
            //builder.RegisterType<UserRepository<ApplicationUser>>().As<IUserRepository<ApplicationUser>>();

            //注册HTTP抽象化类模块
            builder.RegisterModule(new AutofacWebTypesModule());
            builder.RegisterModule<AutofacWebTypesModule>();

            builder.RegisterFilterProvider();

            //将依赖注入视图页
            builder.RegisterSource(new ViewRegistrationSource());
            //设置依赖解析
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));       
        }
    }
}