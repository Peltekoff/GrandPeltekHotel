using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrandPeltekHotel.Models
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Category> RoomCategories { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            

            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Apartments", Description = "Bedroom with a queen-sized bed, living room with a couch, table and fully equpped kitchen" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Name = "Double-bed rooms", Description = "Bedroom with a queen-sized bed and couch" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Name = "Rooms with two separate beds", Description = "Bedroom with two separate medium-sized beds for minimum intimacy" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 4, Name = "Rooms with three separate beds", Description = "Bedroom with three separate medium-sized beds" });

            modelBuilder.Entity<Room>().HasData(new Room { Id = 1, CategoryId = 1 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 2, CategoryId = 1 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 3, CategoryId = 1 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 4, CategoryId = 1 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 5, CategoryId = 1 });

            modelBuilder.Entity<Room>().HasData(new Room { Id = 6, CategoryId = 2 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 7, CategoryId = 2 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 8, CategoryId = 2 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 9, CategoryId = 2 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 10, CategoryId = 2 });

            modelBuilder.Entity<Room>().HasData(new Room { Id = 11, CategoryId = 3 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 12, CategoryId = 3 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 13, CategoryId = 3 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 14, CategoryId = 3 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 15, CategoryId = 3 });

            modelBuilder.Entity<Room>().HasData(new Room { Id = 16, CategoryId = 4 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 17, CategoryId = 4 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 18, CategoryId = 4 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 19, CategoryId = 4 });
            modelBuilder.Entity<Room>().HasData(new Room { Id = 20, CategoryId = 4 });

        }
    }
}
