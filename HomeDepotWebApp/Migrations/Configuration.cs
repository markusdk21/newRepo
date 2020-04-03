namespace HomeDepotWebApp.Migrations
{
    using HomeDepotWebApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeDepotWebApp.Storage.HomeDepotContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HomeDepotWebApp.Storage.HomeDepotContext context)
        {
            context.Tools.AddOrUpdate(t => t.Name, new Tool { Id = 1, Name = "Hækkeklipper", Description= "Hækkeklipperen er udstyret med beskyttede betjeningselementer og en beskyttelsesplade", Depos=100, DayPrice = 50 });
            context.Tools.AddOrUpdate(t => t.Name, new Tool { Id = 2, Name = "Havetromle", Description = "Denne manuelt betjente havetromle gør det meget lettere at komprimere jorden.", Depos = 75, DayPrice = 25 });
            context.Tools.AddOrUpdate(t => t.Name, new Tool { Id = 3, Name = "Pælebor benzin", Description = "Den benzindrevne pælehulsgraver kan betjenes af en person og borer nemt i (hårde) områder.", Depos = 50, DayPrice = 40 });
            context.Tools.AddOrUpdate(t => t.Name, new Tool { Id = 4, Name = "Højtryksrenser 130bar 230V", Description = "Højtryksrenser med sprøjtehoved med 3 indstillinger, til ekstra grundig rengøring", Depos = 125, DayPrice = 150 });

            context.Customers.AddOrUpdate(c => c.Name, new Customer { CustomerId = 1, Name = "Markus Winterberg", Email = "eaamknw@students.eaaa.dk", Username = "markus", Password = "123" });
            context.Customers.AddOrUpdate(c => c.Name, new Customer { CustomerId = 2, Name = "Kevin Jørgensen", Email = "eaakej@students.eaaa.dk", Username = "kevin", Password = "123" });
            context.Customers.AddOrUpdate(c => c.Name, new Customer { CustomerId = 3, Name = "Matias Rask Lauridsen", Email = "eaamrla@students.eaaa.dk", Username = "matias", Password = "123" });
            context.Customers.AddOrUpdate(c => c.Name, new Customer { CustomerId = 4, Name = "Benjamin Søgaard Hansen", Email = "eaambsh@students.eaaa.dk", Username = "benjamin", Password = "123" });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
