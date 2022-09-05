using System.Collections.Generic;
using FA22.P03.Web.Features.Products;
using Microsoft.EntityFrameworkCore;

namespace FA22.P03.Web
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(120);
        }

        }
    }
           
      

  

