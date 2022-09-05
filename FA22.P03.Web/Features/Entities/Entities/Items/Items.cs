using FA22.P03.Web.Features.Items;
using FA22.P03.Web.Features.Listings;
using FA22.P03.Web.Features.Products;

namespace FA22.P03.Web.Features.Entities.Items
{
    public class Items
    {
        public int Id { get; set; }
       public ProductDto Product { get; set; }

       public string Condition { get; set; }

       public ICollection<ItemListings> itemListings { get; set; }
    }
}
