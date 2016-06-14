namespace MoraviaTraning.Web.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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

            context.Products.AddOrUpdate(p => p.Name,
                new Product { Name = "Producto 1", Price = 25, Stock = 5 },
                new Product { Name = "Producto 2", Price = 30, Stock = 5 },
                new Product { Name = "Producto 3", Price = 98, Stock = 5 },
                new Product { Name = "Producto 4", Price = 87, Stock = 5 });


            context.SaveChanges();


        }
    }
}
