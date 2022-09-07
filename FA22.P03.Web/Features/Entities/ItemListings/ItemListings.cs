using FA22.P03.Web.Features.Entities.Items;
using FA22.P03.Web.Features.Entities.Listings;
using FA22.P03.Web.Features.Products;
using System.ComponentModel.DataAnnotations;

namespace FA22.P03.Web.Features.Listings
{
    public class ItemListings
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int ListingId { get; set; }
        public Item item { get; set; }
        
        public Listing Listing { get; set; }


    }


    
}
