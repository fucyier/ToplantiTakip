using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using ToplantiTakip.DataAccess.Concrete.EntityFramework;
using ToplantiTakip.Domain.Concrete;

namespace ToplantiTakip.DataAccess.Configurations
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<ToplantiTakipContext>
    {
        protected override void Seed(ToplantiTakipContext context)
        {
            InitializeIdentityForEf(context);
            base.Seed(context);
        }

        private void InitializeIdentityForEf(ToplantiTakipContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            const string adminName = "admin";
            const string adminFirstName = "Eren";
            const string adminLastName = "Tatar";
            const string adminEmail = "erentatar@hotmail.com";
            const string adminPassword = "admin123";
            const string adminRole = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(adminRole);

            if (role == null)
            {
                role = new IdentityRole(adminRole);
                var roleResult = roleManager.Create(role);
            }

            //Create User account if it does not exist
            var user = userManager.FindByEmail(adminEmail);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = adminName,
                    FirstName = adminFirstName,
                    LastName = adminLastName,
                    Email = adminEmail,
                };
                var result = userManager.Create(user, adminPassword);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);

            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}