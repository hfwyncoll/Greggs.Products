namespace Greggs.Products.Api.Models
{
    public class ProductInternational
    {
        // PriceInPounds is included in here deliberately as it may be of use to the User Story 2 user
        // If that wasn't needed, would remove PriceInPounds from the constructor and as a property
        public ProductInternational(Product product)
        {
            Name = product.Name;
            PriceInPounds = product.PriceInPounds;
        }
        public string Name { get; set; }
        public decimal PriceInPounds { get; set; }
        public decimal PriceInEur { get; set; }
    }
}
