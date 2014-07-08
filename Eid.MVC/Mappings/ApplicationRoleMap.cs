using Eid.MVC.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eid.MVC.Mappings
{
    public class ApplicationRoleMap: ClassMap<ApplicationRole>
    {
        public ApplicationRoleMap()
        {
            Table("ASPNETROLES");
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Description);
        }
    }
}