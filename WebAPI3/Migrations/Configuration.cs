namespace WebAPI3.Migrations
{
    using WebAPI3.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAPI3.Models.WebAPI3Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebAPI3.Models.WebAPI3Context context)
        {
            context.Users.AddOrUpdate(x => x.Id,
        new User() { Id = 1, Name = "Yura" },
        new User() { Id = 2, Name = "Vasia" },
        new User() { Id = 3, Name = "Marina" }
        );
        
        context.Cards.AddOrUpdate(x => x.Id,
                new Cards()
                {
                    Id = 1,
                    CardName = "Platin",
                    NumberCard = 181231673,
                    UserId = 1,
                    CardMoney = 9.99M,
                },
                new Cards()
                {
                    Id = 2,
                    CardName = "gold",
                    NumberCard = 3918593,
                    UserId = 2,
                    CardMoney = 12.9M,
                },
                new Cards()
                {
                    Id = 3,
                    CardName = "Silver",
                    NumberCard = 39208133,
                    UserId = 1,
                    CardMoney = 1M,
                },
                new Cards()
                {
                    Id = 4,
                    CardName = "Platin",
                    NumberCard = 390194844,
                    UserId = 3,
                    CardMoney = 1999M,
                }
                );
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
        }
    }
}
