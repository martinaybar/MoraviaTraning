namespace MoraviaTraning.Web.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MoraviaTraning.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.ApplicationDbContext context)
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

            context.Roles.AddOrUpdate(
              p => p.Name,
              new IdentityRole { Id ="1", Name = "Client" },
              new IdentityRole { Id = "2", Name = "Admin" },
              new IdentityRole { Id = "3", Name = "WebAdmin" }
            );
            context.SaveChanges();

            context.Products.AddOrUpdate(
              p => p.Name,
              new Product { Id = Guid.NewGuid().ToString(), Name = "Galletita Trio XXX", Price = 56.67, Stock = 10  },
              new Product { Id = Guid.NewGuid().ToString(), Name = "Caramelo Sugus", Price = 45.78, Stock = 10 },
              new Product { Id = Guid.NewGuid().ToString(), Name = "Chicle XXX", Price = 25.45, Stock = 10 },
              new Product { Id = Guid.NewGuid().ToString(), Name = "Chocolate Cofler", Price = 30, Stock = 10 }
            );
            context.SaveChanges();




        }
    }
}
