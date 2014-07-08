using Microsoft.AspNet.Identity;
using System;

namespace AspNet.Identity.Abstract
{
    public class IdentityRole : IRole
    {
        public IdentityRole()
        {
            Id = Guid.NewGuid().ToString();
        }        
        public IdentityRole(string name)
            : this()
        {
            Name = name;
        }        
        public virtual string Id { get; set; }        
        public virtual string Name { get; set; }

    }
}
