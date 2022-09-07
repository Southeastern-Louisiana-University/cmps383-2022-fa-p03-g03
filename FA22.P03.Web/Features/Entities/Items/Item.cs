using FA22.P03.Web.Features.Entities.Entities.Products;
using FA22.P03.Web.Features.Items;
using FA22.P03.Web.Features.Listings;
using FA22.P03.Web.Features.Products;

namespace FA22.P03.Web.Features.Entities.Items
{
    public class Item
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
       public Product Product { get; set; }
       public string ProductName { get; set; }
       public string Condition { get; set; }

       public ICollection<ItemListings> itemListings { get; set; }
    }
}
