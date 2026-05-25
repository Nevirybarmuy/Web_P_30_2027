namespace Marketplace.Model
{
    public class Category : EFModel
    {
        public ICollection<Product>? Products { get; set; }
    }
}
