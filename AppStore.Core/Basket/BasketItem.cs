using AppStore.Domain.Products;

namespace AppStore.Domain.Basket
{
    public class BasketItem
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}