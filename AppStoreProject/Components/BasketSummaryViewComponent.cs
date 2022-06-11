using AppStore.Domain.Basket;
using Microsoft.AspNetCore.Mvc;

namespace AppStore.ShopProjectUI.Components
{
    public class BasketSummaryViewComponent:ViewComponent
    {
        private readonly Basket _basket;
        public BasketSummaryViewComponent(Basket basket)
        {
            _basket = basket;   
        }
        public IViewComponentResult Invoke()
        {
            return View(_basket);
        }
    }
}
