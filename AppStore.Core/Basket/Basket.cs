using AppStore.Domain.Products;

namespace AppStore.Domain.Basket
{
    public class Basket
    {
        private List<BasketItem> _items = new();
        //private List<BasketItem> _Items = new List<BasketItem>();
        
        //public int Id { get; set; }

        public virtual void Add(Product product, int quantity)
        {
            var basketItem = _items.Where(c => c.Product?.Id == product.Id).FirstOrDefault();

            if (basketItem != null)
            {
                basketItem.Quantity += quantity;

            }
            else
            {
                _items.Add(new BasketItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }

        }
        public virtual void Remove(Product product) => _items.RemoveAll(c=> c.Product?.Id == product.Id);
        public virtual int TotalPrice() => _items.Sum(c => c.Product.Price * c.Quantity);
        public virtual void Cleaar() => _items.Clear();
        public IEnumerable<BasketItem> Items => _items;

    }
}
