using FA22.P03.Web.Features.Entities.Listings;
using FA22.P03.Web.Features.Products;
using Microsoft.AspNetCore.Cors.Infrastructure;
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
    },
    new ProductDto
    {
        Id = currentId++,
        Name = "Donkey Kong 64",
        Description = "Moderate Condition Donkey Kong 64 cartridge for the Nintendo 64",
        
    },
    new ProductDto
    {
        Id = currentId++,
        Name = "Half-Life 2: Collector's Edition",
        Description = "Good condition with all 5 CDs, booklets, and material from original",

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
        

        [HttpPost("/api/products")]
        public ActionResult<ProductDto> CreateProduct (ProductDto product)
        {
            if (string.IsNullOrWhiteSpace(product.Name) ||
           product.Name.Length > 120 ||
           string.IsNullOrWhiteSpace(product.Description))
            {
                return BadRequest();
            }
            product.Id = currentId++;
            products.Add(product);
            return  StatusCode(201, CreatedAtRoute("GetProductById", new { id = product.Id++ }, product));

        }

        [HttpPut("{id:int}")]
        public ActionResult<ProductDto> UpdateProduct (int id, ProductDto product)
        {
            if (string.IsNullOrWhiteSpace(product.Name) ||
           product.Name.Length > 120 ||
           string.IsNullOrWhiteSpace(product.Description))
            {
                return BadRequest();
            }

            var current = products.FirstOrDefault(x => x.Id == id);
            if (current == null)
            {
                return NotFound();
            }

            current.Name = product.Name;
            current.Description = product.Description;

            return Ok(current);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ProductDto> DeleteProduct(int id)
        {
            var current = products.FirstOrDefault(x => x.Id == id);
            if (current == null)
            {
                return NotFound();
            }

            products.Remove(current);

            return Ok();
        }



    }
}
