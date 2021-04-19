using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DataContext
{
    public class RentServiceDBContext : DbContext
    {
      

            public RentServiceDBContext() : base("name=RentServiceDB")
            {
            }


             public virtual DbSet<Tool> Tools { get; set; }
            public virtual DbSet<Customer> Customers { get; set; }

            public virtual DbSet<Reservation> Reservations { get; set; }

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

