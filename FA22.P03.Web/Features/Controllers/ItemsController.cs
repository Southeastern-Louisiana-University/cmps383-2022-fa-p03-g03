using FA22.P03.Web.Features.Entities.Items;
using FA22.P03.Web.Features.Items;
using FA22.P03.Web.Features.Products;
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


        
        
    }
}
