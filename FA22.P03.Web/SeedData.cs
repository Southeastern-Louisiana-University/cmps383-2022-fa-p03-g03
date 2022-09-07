
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using FA22.P03.Web.Features.Entities.Entities.Products;
using FA22.P03.Web.Features.Products;
using System.Net;
using System.Reflection.Emit;
using FA22.P03.Web.Features.Items;
using FA22.P03.Web.Features.Entities.Items;
using System.Diagnostics;

namespace FA22.P03.Web
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DataContext>>()))
            { 
                if (!context.Products.Any())
                {


                    context.Products.AddRange(new List<Product>()
                      {
                        new Product
                        {
                            Name = "Netindo Switch",
                            Description = "Nice game this is",
                            
                              
                        },
                    new Product
                        {
                        Name = "Big gun99",
                        Description = "big and strong",

                        },
                      new Product
                     {
                        Name = "Haymaker 45",
                        Description = "pretty hairy",

                     },

                   }) ; 
               

                    context.SaveChanges();

                }
                
            }
        } 
    }
}
