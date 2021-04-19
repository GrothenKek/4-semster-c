
using CodeFirst.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace CodeFirst.DataContext
{


    public class RentServiceContext : DbContext
    {

        public RentServiceContext() : base("name=RentServiceContext")
        {
           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<RentServiceContext, Migrations.Configuration>());
        }


        public DbSet<Tool> Tools { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
               .HasMany<Reservation>(b => b.Reservations)
               .WithRequired(c => c.Customer)
               .HasForeignKey<string>(s => s.CustomerId);

            modelBuilder.Entity<Tool>()
                .HasMany<Reservation>(b => b.Reservations)
                .WithRequired(p => p.Tool)
                .HasForeignKey<int>(f => f.ToolId);



            
        }

    }
}
