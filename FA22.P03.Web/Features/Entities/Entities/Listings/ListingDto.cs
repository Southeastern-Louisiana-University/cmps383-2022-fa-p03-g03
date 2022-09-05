using FA22.P03.Web.Features.Listings;

namespace FA22.P03.Web.Features.Entities.Listings
{
    public class ListingDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public decimal Price { get; set; }
        public DateTimeOffset StartUtc { get; set; }

        public DateTimeOffset EndUtc { get; set; }

    }
}
