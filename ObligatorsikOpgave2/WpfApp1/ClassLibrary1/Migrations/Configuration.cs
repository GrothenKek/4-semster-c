namespace ClassLibrary1.Migrations
{
    using ClassLibrary1.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClassLibrary1.DataContext.RentServiceDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClassLibrary1.DataContext.RentServiceDBContext context)
        {
            var PressureWasher = new Tool { ToolId = 1, Name = "Pressure Washer", Description = "much wash", Status = Status.StatusEnum.NotAvailable, PricePrDay = 200, };
            var PowerDrill = new Tool { ToolId = 2, Name = "PowerDrill", Description = "much Drill", Status = Status.StatusEnum.NotAvailable, PricePrDay = 250, };
            var TableSaw = new Tool { ToolId = 3, Name = "TableSaw", Description = "Much saw very good", Status = Status.StatusEnum.NotAvailable, PricePrDay = 300, };
            var AngleGrinder = new Tool { ToolId = 4, Name = "AngleGrinder", Description = "Grinding so hard", Status = Status.StatusEnum.available, PricePrDay = 400, };
            var BigSaw = new Tool { ToolId = 5, Name = "BigSaw", Description = "much big", Status = Status.StatusEnum.NotAvailable, PricePrDay = 450, };


            var res1 = new Reservation { ResId = 1, StartDate = new DateTime(2021, 4, 10), EndDate = new DateTime(2021, 4, 30), StorageStatus = ResStatus.Reserved, ToolId = 1, CustomerId = "TorbenClausenl@gmail.com" };
            var res2 = new Reservation { ResId = 2, StartDate = new DateTime(2021, 4, 13), EndDate = new DateTime(2021, 4, 30), StorageStatus = ResStatus.Reserved, ToolId = 2, CustomerId = "DollarClaus@gmail.com" };
            var res3 = new Reservation { ResId = 3, StartDate = new DateTime(2021, 4, 14), EndDate = new DateTime(2021, 4, 20), StorageStatus = ResStatus.Reserved, ToolId = 3, CustomerId = "SlankeDex@gmail.com", };
            var res4 = new Reservation { ResId = 4, StartDate = new DateTime(2021, 4, 16), EndDate = new DateTime(2021, 4, 20), StorageStatus = ResStatus.Reserved, ToolId = 5, CustomerId = "SlankeDex@gmail.com", };


            List<Reservation> resClaus = new List<Reservation> { res1 };
            var c1 = new Customer { Email = "TorbenClausenl@gmail.com", Name = "Torben Clausen", Password = "Kodeord", Reservations = resClaus, };

            List<Reservation> resDollar = new List<Reservation> { res2 };
            var c2 = new Customer { Email = "DollarClaus@gmail.com", Name = "Dollar Claus", Password = "Kodeord", Reservations = resDollar, };

            var c3 = new Customer { Email = "JimDaggerthugger@gmail.com", Name = "Jim Daggerthugger", Password = "Kodeord", Reservations = new List<Reservation> { }, };

            List<Reservation> resDex = new List<Reservation> { res3, res4 };
            var c4 = new Customer { Email = "SlankeDex@gmail.com", Name = "Slanke Dex", Password = "Kodeord", Reservations = resDex, };

            var c5 = new Customer { Email = "DukkeMogens@gmail.com", Name = "Dukke Mogens", Password = "Kodeord", Reservations = new List<Reservation> { }, };













            context.Tools.Add(PressureWasher);

            context.Tools.Add(PowerDrill);

            context.Tools.Add(TableSaw);

            context.Tools.Add(AngleGrinder);

            context.Tools.Add(BigSaw);
            context.SaveChanges();



            Console.WriteLine();
            Console.WriteLine("list of tools currently in the database :");
            Console.WriteLine();












            context.Customers.Add(c1);

            context.Customers.Add(c2);

            context.Customers.Add(c3);

            context.Customers.Add(c4);

            context.Customers.Add(c5);
            context.SaveChanges();


            Console.WriteLine("list of users currently in the database :");
            Console.WriteLine();






            context.Reservations.Add(res1);
            context.Reservations.Add(res2);
            context.Reservations.Add(res3);
            context.Reservations.Add(res4);
            context.SaveChanges();
            Console.WriteLine("list of res currently in the database :");





          
            base.Seed(context);

        }
    }
}
