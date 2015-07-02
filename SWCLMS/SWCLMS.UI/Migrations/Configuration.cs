using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SWCLMS.UI.Models;

namespace SWCLMS.UI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SWCLMS.UI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SWCLMS.UI.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //TODO make this so we don't duplicate users every time seed is run.
            

            if (roleMgr.RoleExists("Admin"))
            {
                return;
            }
            else
            {
                CreateRoles(roleMgr);
                CreateSampleUsers(userMgr);
            }
        }

        private void CreateSampleUsers(UserManager<ApplicationUser> userMgr)
        {
            var student1 = new ApplicationUser()
            {
                UserName = "student1@gmail.com"
            };
            userMgr.Create(student1, "testing123");
            userMgr.AddToRole(student1.Id, "Student");

            var student2 = new ApplicationUser()
            {
                UserName = "student2@gmail.com"
            };
            userMgr.Create(student2, "testing123");
            userMgr.AddToRole(student2.Id, "Student");

            var parent = new ApplicationUser()
            {
                UserName = "parent@gmail.com"
            };
            userMgr.Create(parent, "testing123");
            userMgr.AddToRole(parent.Id, "Parent");

            var teacher = new ApplicationUser()
            {
                UserName = "teacher@gmail.com"
            };
            userMgr.Create(teacher, "testing123");
            userMgr.AddToRole(teacher.Id, "Teacher");

            var admin = new ApplicationUser()
            {
                UserName = "admin@gmail.com"
            };
            userMgr.Create(admin, "testing123");
            userMgr.AddToRole(admin.Id, "Admin");

        }

        private void CreateRoles(RoleManager<IdentityRole> roleMgr)
        {
            roleMgr.Create(new IdentityRole("Admin"));
            roleMgr.Create(new IdentityRole("Teacher"));
            roleMgr.Create(new IdentityRole("Parent"));
            roleMgr.Create(new IdentityRole("Student"));
        }
    }
}
