using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FA22.P03.Web.Features.Controllers
{
    [Route("api/listings")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ListingsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet("api/listings")]
        public ActionResult GetListings()
        {

        }


    }
}
