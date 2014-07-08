using Eid.MVC.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eid.MVC.Mappings
{
    public class ApplicationUserMap : ClassMap<ApplicationUser>
    {
        public ApplicationUserMap()
        {
            Table("ASPNETUSERS");
            Id(x => x.Id);
            Map(x => x.UserName);
            Map(x => x.PasswordHash);
            Map(x => x.SecurityStamp);
            Map(x => x.PhoneNumber);
            Map(x => x.PhoneNumberConfirmed);
            Map(x => x.Email);
            Map(x => x.EmailConfirmed);            
            //Map(x => x.LockoutEnabled);
            //Map(x => x.LockoutEndDate).CustomType("string");
            //Map(x => x.AccessFailedCount);
            Map(x => x.RealName);
            Map(x => x.PasswordQuestion);
            Map(x => x.PasswordAnswer);
        }
    }
}