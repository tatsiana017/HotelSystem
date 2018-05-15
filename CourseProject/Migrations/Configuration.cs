namespace CourseProject.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CourseProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CourseProject.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

        //    var userManager = new ApplicationUserManager(new UserStore<Models.ApplicationUser>(context));

        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

        //    // создаем две роли
        //    var role1 = new IdentityRole { Name = "Administrator" };
        //    var role2 = new IdentityRole { Name = "User" };

        //    // добавл€ем роли в бд
        //    roleManager.Create(role1);
        //    roleManager.Create(role2);

        //    // создаем пользователей
        //    var admin = new Models.ApplicationUser { Id = Guid.NewGuid().ToString(), Email = "admin@mail.ru", UserName = "admin" };
        //    string password = "Admin_1";
        //    var result = userManager.Create(admin, password);

        //    // если создание пользовател€ прошло успешно
        //    if (result.Succeeded)
        //    {
        //        // добавл€ем дл€ пользовател€ роль
        //        userManager.AddToRole(admin.Id, role1.Name);
        //        userManager.AddToRole(admin.Id, role2.Name);
        //    }
        //    base.Seed(context);



        //    context.Category.Add(new Models.Category
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Name = "Honeymoon Room",
        //        Description = "Hомер дл€ молодоженов, с большой кроватью KING SIZE и дополнительным презентом от отел€",
        //        Rooms = new List<Models.Rooms>()
        //    });
        //    context.Category.Add(new Models.Category
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Name = "King Suite",
        //        Description = "2 спальни, гостина§ и рабочий кабинет",
        //        Rooms = new List<Models.Rooms>()
        //    });
        //    context.Category.Add(new Models.Category
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Name = "TWIN",
        //        Description = "ƒвухместный номер с двум§ раздельными кроват€ми",
        //        Rooms = new List<Models.Rooms>()
        //    });
        //    context.Category.Add(new Models.Category
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Name = "SNGL",
        //        Description = "ќдноместный номер",
        //        Rooms = new List<Models.Rooms>()
        //    });
        //    context.Category.Add(new Models.Category
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Name = "DBL",
        //        Description = "ƒвухместный номер с одной большой двуспальной кроватью",
        //        Rooms = new List<Models.Rooms>()
        //    });
        //    context.Category.Add(new Models.Category
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Name = "Suite",
        //        Description = "Ќомер повышенной комфортности, состо€щий из гостиной и спальни",
        //        Rooms = new List<Models.Rooms>()
        //    });
        //    context.Category.Add(new Models.Category
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Name = "President",
        //        Description = "2 спальные комнаты, гостина€, кабинет, 3 ванные комнаты",
        //        Rooms = new List<Models.Rooms>()
        //    });
        }
    }
}
