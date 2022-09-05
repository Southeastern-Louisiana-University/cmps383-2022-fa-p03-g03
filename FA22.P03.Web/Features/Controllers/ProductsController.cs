using FA22.P03.Web.Features.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FA22.P03.Web.Features.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static int currentId = 1;
        private static List<ProductDto> products = new List<ProductDto>
{
    new ProductDto
    {
        Id = currentId++,
        Name = "Super Mario World",
        Description = "Super Nintendo (SNES) System. Mint Condition",
        Price = 259.99m,
    },
    new ProductDto
    {
        Id = currentId++,
        Name = "Donkey Kong 64",
        Description = "Moderate Condition Donkey Kong 64 cartridge for the Nintendo 64",
        Price = 199m,
    },
    new ProductDto
    {
        Id = currentId++,
        Name = "Half-Life 2: Collector's Edition",
        Description = "Good condition with all 5 CDs, booklets, and material from original",
        Price = 559.99m
    }
};

        [HttpGet]
        public ActionResult<ProductDto[]>  GetAllProducts()
        {
            return products.ToArray();

        }

        [HttpGet("{id:int}")]
        public ActionResult<ProductDto> GetProductById(int id)
            {
            var result = products.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        
        
        
    }
}
