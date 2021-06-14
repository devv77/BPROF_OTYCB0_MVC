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
