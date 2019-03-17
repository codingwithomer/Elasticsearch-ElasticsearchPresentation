using Microsoft.EntityFrameworkCore;
using WhatIsElasticSearch.Entities;

namespace WhatIsElasticSearch.DAL.EntityFramework
{
    public class EFDbContext : DbContext
    {
        // public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        // {

        // }

        public EFDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Username=elastic_user;Password=QweAsd123*;Database=northwind");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // modelBuilder.Entity<Product>()
            //     .Property(b => b.unit_price)
            //     .HasColumnType("real");

            modelBuilder.Entity<Product>()
            .HasOne<Category>()
            .WithMany();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
