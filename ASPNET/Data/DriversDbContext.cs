using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System;





namespace Data
{
    public class DriversDbContext:IdentityDbContext<IdentityUser>
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DriversDbContext(DbContextOptions<DriversDbContext> opt):base(opt)
        {

        }

        public DriversDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().
                    //UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Driver.mdf;integrated security=True;MultipleActiveResultSets=True");
                    UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DriverDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //TODO alap admin
            modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "341743f0-dee2–42de-bbbb-59kmkkmk72cf6", Name = "Customer", NormalizedName = "CUSTOMER" }
            );

            var appUser = new IdentityUser
            {
                Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                Email = "test.elek@gmail.com",
                NormalizedEmail = "test.elek@gmail.com",
                EmailConfirmed = true,
                UserName = "test.elek@gmail.com",
                NormalizedUserName = "test.elek@gmail.com",
                SecurityStamp = string.Empty
            };

            var appUser2 = new IdentityUser
            {
                Id = "e2174cf0–9412–4cfe-afbf-59f706d72cf6",
                Email = "eclestone@f1.com",
                NormalizedEmail = "eclestone@f1.com",
                EmailConfirmed = true,
                UserName = "eclestone@f1.com",
                NormalizedUserName = "eclestone@f1.com",
                SecurityStamp = string.Empty
            };

            appUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Abcd1234");
            appUser2.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Abcd1234");


            modelBuilder.Entity<IdentityUser>().HasData(appUser);
            modelBuilder.Entity<IdentityUser>().HasData(appUser2);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                UserId = "02174cf0–9412–4cfe-afbf-59f706d72cf6"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "341743f0-dee2–42de-bbbb-59kmkkmk72cf6",
                UserId = "e2174cf0–9412–4cfe-afbf-59f706d72cf6"
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity
                .HasOne(Driver => Driver.OwnTeam)
                .WithMany(Team => Team.Drivers)
                .HasForeignKey(Driver => Driver.TID);
            });
            modelBuilder.Entity<Team>(entity =>
            {
                entity
                .HasOne(Team => Team.League)
                .WithMany(League => League.Teams)
                .HasForeignKey(Team => Team.LID);
            });
        }
    }
}
