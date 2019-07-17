using System;
using System.Collections.Generic;
using System.Text;
using BookCase.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookCase.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Create a new user for Identity Framework
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            // Create three genres
            modelBuilder.Entity<Genre>().HasData(
                new Genre()
                {
                    Id = 1,
                    Name = "Horror"
                },
                new Genre()
                {
                    Id = 2,
                    Name = "Science Fiction"
                },
                new Genre()
                {
                    Id = 3,
                    Name = "Crime and Detective"
                }
            );

            // Create three authors
            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = 1,
                    FirstName = "Stephen",
                    LastName = "King"
                },
                new Author()
                {
                    Id = 2,
                    FirstName = "Ray",
                    LastName = "Bradbury"
                },
                new Author()
                {
                    Id = 3,
                    FirstName = "Agatha",
                    LastName = "Christie"
                }
            );

            // Create three books
            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = 1,
                    ISBN = "0670813028",
                    Title = "It",
                    AuthorId = 1,
                    GenreId = 1,
                    DatePublished = new DateTime(1986, 09, 15),
                    OwnerId = user.Id
                },
                new Book()
                {
                    Id = 2,
                    ISBN = "9780743247221",
                    Title = "Fahrenheit 451",
                    AuthorId = 2,
                    GenreId = 2,
                    DatePublished = new DateTime(1953, 10, 19),
                    OwnerId = user.Id
                },
                new Book()
                {
                    Id = 3,
                    ISBN = "9780062693662",
                    Title = "Murder on the Orient Express",
                    AuthorId = 3,
                    GenreId = 3,
                    DatePublished = new DateTime(1934, 1, 1),
                    OwnerId = user.Id
                }
            );
        }
    }
}
