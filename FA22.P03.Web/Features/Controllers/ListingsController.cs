using FA22.P03.Web.Features.Entities.Listings;
using FA22.P03.Web.Features.Listings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<ActionResult<IQueryable<ListingDto>>> GetListings()
        {
            var listings = await _dataContext.Listings.Select(t =>
            new ListingDto()
            {
                Id = t.Id,
                Description = t.Description,
                Price = t.Price,
                Name = t.Name,
                StartUtc = t.StartUtc,
                EndUtc = t.EndUtc,
            }).ToListAsync();
            return Ok(listings);
        }



        [HttpGet("{id:int}")]
        public async Task <ActionResult<ListingDto>> GetListingsById(int id)
        {var listings = await _dataContext.Listings.Select(t =>
            new ListingDto()
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Price = t.Price,
                StartUtc = t.StartUtc,
                EndUtc = t.EndUtc,
            }).SingleOrDefaultAsync(t => t.Id == id);

            if(listings == null)
            {
                return NotFound();
            }

            return Ok(listings);
    }


    [HttpPost("api/listings")]
        public async Task <ActionResult<ListingDto>> CreateListing(ListingDto listing)
        {
            _dataContext.Entry(listing).Property(x => x.Name);
            var dto = new ListingDto()
            {
                Id = listing.Id,
                Name = listing.Name,
                Description = listing.Description,
                Price = listing.Price,
                StartUtc = DateTimeOffset.UtcNow.AddDays(-1),
                EndUtc = DateTimeOffset.UtcNow.AddDays(1),
            };

            await _dataContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetListingsById), dto);
        }
    }
}
