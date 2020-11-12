using JWTExample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefreshTokenExample.DBContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Mert", Surname = "OĞUZ", Username = "mertoguz", Password = "XXXXXX" },
                new User { Id = 2, Name = "tesname", Surname = "testsurname", Username = "testnametestsurname", Password = "YYYYYY" }
                );
        }
    }

    //public class UserFactory : IDesignTimeDbContextFactory<Context>
    //{
    //    public Context CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<Context>();
    //        optionsBuilder.UseSqlServer("Server=.;Database=RefreshTokenDB;Trusted_Connection=True;");

    //        return new Context(optionsBuilder.Options);
    //    }
    //}
}
