namespace LicenseManagerMvc.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LicenseManagerMvc.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LicenseManagerMvc.Models.ApplicationDbContext context)
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

            context.Herstellers.AddOrUpdate(
                h => h.Name,
                new Models.Hersteller { Name = "Microsoft" }
            );

            context.Genres.AddOrUpdate(
                g => g.Name,
                new Models.Genre { Name = "Betriebssystem" },
                new Models.Genre { Name = "Entwicklung" }
            );
        }
    }
}
