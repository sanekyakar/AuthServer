using AuthServer.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.DAL
{
    public class AuthContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var adminRole=new Role();


            //var UserRole = new Role { Name = "User", Id = 2 };
            //var observerRole=new Role { Name ="Observer",Id=3 };
            //var adminRole= new Role { Name ="admin",Id=1 };

            //var adminUser = new User { Id = 1, Login = "AlmazAdmin", Password = "qwerty", Role = adminRole };

            //modelBuilder.Entity<Role>().HasData(UserRole,observerRole,adminRole);

            
        }
    }
}
