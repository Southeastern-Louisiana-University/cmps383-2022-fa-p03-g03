using FA22.P03.Web.Features.Entities.Items;
using FA22.P03.Web.Features.Items;
using System.Threading.Tasks;
using FA22.P03.Web.Features.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace FA22.P03.Web.Features.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ItemsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
      
        [HttpGet]
        public IQueryable<ItemDtos> GetItems()
        {
            var items = from item in _dataContext.Items
                        select new ItemDtos()
                        {
                            Id = item.Id,
                            ProductId = item.ProductId,
                            Condition = item.Condition,
                            ProductName = item.ProductName,
                        };
            return items;
        }
       
        [HttpGet("{id:int}")]
        public ActionResult GetAItemById(int id)
        {
            var result = _dataContext.Items.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
       
      
        [HttpPost]
     
        public async Task<ActionResult<ItemDtos>> CreateAItem(Item itemDto)
        {
            _dataContext.Items.Add(itemDto);
            await _dataContext.SaveChangesAsync();
            _dataContext.Entry(itemDto).Property(x => x.ProductId);
            _dataContext.Entry(itemDto).Property(x => x.Condition);
            if(itemDto.Condition == null|| itemDto.ProductId <= 0)
            {
                return BadRequest();
            }
            var dto = new ItemDtos()
            {
                Id = itemDto.Id,
                ProductId = itemDto.ProductId,
                //ProductName = itemDto.ProductName,
                Condition = itemDto.Condition,
            };


            return StatusCode( 201,dto);

        }
        
        [HttpDelete("/api/items/{id}")]
        public async Task<IActionResult> DeleteAItem(int id)
        {
            var itemDto = await _dataContext.Items.FindAsync(id);
            if(itemDto == null)
            {
                return NotFound();
            }

            _dataContext.Items.Remove(itemDto);
            _dataContext.SaveChangesAsync();
            return Ok();
        }
        /*
        [HttpDelete("{id:int}")]
        public ActionResult<ItemDtos> DeleteItem(int id)
        {
            var current = _dataContext.Items.FirstOrDefault(x => x.Id == id);
            if(current == null)
            {
                return BadRequest();
            }
            _dataContext.Items.Remove(current);
            _dataContext.SaveChanges();
            return Ok(current);
        }
        */
        
    }
}
