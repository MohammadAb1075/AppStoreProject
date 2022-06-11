using AppStore.Domain.Basket;

namespace AppStore.ShopProjectUI.Models
{
    public class BasketPageViewModel
    {
        public Basket Basket { get; set; }
        public String ReturnURL { get; set; }
    }
}
