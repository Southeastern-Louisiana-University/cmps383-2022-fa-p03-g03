using FA22.P03.Web.Features.Items;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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


        [HttpGet("api/items")]
        public ActionResult GetItems()
        {
            var items = _dataContext.Items;

            return Ok(items);
        }
        /*
        [HttpPost]
        public ActionResult CreateItems(ItemDtos items)
        {
            var itemToCreate = new ItemDtos()
            {
                Id = items.Id,
                ProductId = items.ProductId,
                ProductName = items.ProductName,
                Condition = items.Condition,
            };
            if (string.IsNullOrWhiteSpace(itemToCreate.ProductName) ||
           itemToCreate.ProductName.Length > 120 ||
           itemToCreate.ProductId == null)
            {
                return BadRequest();
            }
            _dataContext.Items.Add(itemToCreate);
            return Ok(itemToCreate);
            _dataContext.SaveChanges();

        }
        */
    }
}
