using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PaymentCard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentCard.Infrastructure.DataContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        DbSet<Card> Cards { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Card>().HasKey(i => i.Id);
        }

        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Server=DESKTOP-SM0C90P\\SQLEXPRESS;Database=CardsDB;Trusted_Connection=True;MultipleActiveResultSets=True");
                return new ApplicationDbContext(options.Options);
            }
        }




    }
}
