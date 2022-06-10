using AppStore.Domain.Products;

namespace AppStore.Domain.Orders
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}
