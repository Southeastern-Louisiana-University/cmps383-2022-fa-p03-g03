using FA22.P03.Web.Features.Entities.Entities.Products;
using FA22.P03.Web.Features.Entities.Items;
using FA22.P03.Web.Features.Entities.Listings;
using FA22.P03.Web.Features.Products;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace FA22.P03.Web.Features.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ProductsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public ActionResult<ProductDto> GetAllProducts()
        {
            var products = _dataContext.Products;            

            return Ok(products);
        }
        [HttpGet("{id:int}")]
        public ActionResult<ProductDto> GetProductById(int id)
        {
            var result = _dataContext.Products.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
       
        

        [HttpPost("/api/products")]
        public ActionResult<ProductDto> CreateProduct(ProductDto product)
        {
            var productToCreate = new Product()
            {
                Name = product.Name,
                Description = product.Description,

            };
            
            if (string.IsNullOrWhiteSpace(productToCreate.Name) ||
           productToCreate.Name.Length > 120 ||
           string.IsNullOrWhiteSpace(productToCreate.Description))
            {
                return BadRequest();
            }
            _dataContext.Products.Add(productToCreate);
            _dataContext.SaveChanges();
            return StatusCode(201, CreatedAtRoute("GetProductById", new { id = productToCreate.Id }, productToCreate));

        }

        [HttpPut("{id:int}")]
        public ActionResult<ProductDto> UpdateProduct(int id, ProductDto productDto)
        {
            if (string.IsNullOrWhiteSpace(productDto.Name) ||
          productDto.Name.Length > 120 ||
          string.IsNullOrWhiteSpace(productDto.Description))
            {
                return BadRequest();
            }

            var current = _dataContext.Products.FirstOrDefault(x => x.Id == id);
            if (current == null)
            {
                return NotFound();
            }

            current.Name = productDto.Name;
            current.Description = productDto.Description;

            _dataContext.SaveChanges();
            return Ok(current);

        }
        [HttpDelete("{id:int}")]
        public ActionResult<ProductDto> DeleteProduct(int id)
        {
            var current = _dataContext.Products.FirstOrDefault(x => x.Id == id);
            if (current == null)
            {
                return NotFound();
            }

            _dataContext.Products.Remove(current);
            _dataContext.SaveChanges();

            return Ok(current);
        }



        /*
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
   */
    };
/*
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


*/
    }

