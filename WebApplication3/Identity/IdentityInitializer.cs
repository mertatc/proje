using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.Entitiy;

namespace WebApplication3.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {

        protected override void Seed(IdentityDataContext context)
        {
            //roller
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new ApplicationRole("admin", "yönetici");

                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new ApplicationRole("user", "user rolü");

                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "mert"))
            {
                var store = new UserStore<IdentityUser>(context);
                var manager = new UserManager<IdentityUser>(store);
                var user = new ApplicationUser() { Name = "mert", Surname = "atc", UserName = "mertatc", Email = "mertatc@hotmail.com" };

                manager.Create(user,"1234567");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }

            //user
            base.Seed(context);
        }

    }
}