using FA22.P03.Web.Features.Entities.Listings;
using FA22.P03.Web.Features.Products;

namespace FA22.P03.Web.Features.Listings
{
    public class ItemListings
    {
       public int Id { get; set; }  
      public  ProductDto Product { get; set; }
      public ListingDto Listing { get; set; }


    }
}
