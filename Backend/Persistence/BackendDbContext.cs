using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Persistence
{
    
    namespace Backend.Persistence
    {
        public class BackendDbContext : DbContext
        {
            public BackendDbContext(DbContextOptions<BackendDbContext> options)
                : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Reservation>()
                    .HasOne(r => r.Contact)
                    .WithMany(c => c.ReservationsList)
                    .HasForeignKey(r => r.ContactId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            }

            public DbSet<Reservation> Reservations { get; set; }
            public DbSet<Contact> Contacts { get; set; }
        }
    }

}
