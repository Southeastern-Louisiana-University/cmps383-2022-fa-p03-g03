using System.Collections.Generic;
using System.Net;
using FA22.P03.Web.Features.Entities.Entities.Products;
using FA22.P03.Web.Features.Entities.Items;
using FA22.P03.Web.Features.Entities.Listings;
using FA22.P03.Web.Features.Listings;
using FA22.P03.Web.Features.Products;
using Microsoft.EntityFrameworkCore;

namespace FA22.P03.Web
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
       public DbSet<Product> Products { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Item> Items { get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(120);

            modelBuilder.Entity<Item>();

            modelBuilder.Entity<Listing>();

            modelBuilder.Entity<ItemListings>();
                
            
            

        }

        }
    }
           
      

  

