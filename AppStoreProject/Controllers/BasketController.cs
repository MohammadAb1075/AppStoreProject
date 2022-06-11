using AppStore.Domain.Basket;
using AppStore.Domain.Products;
using AppStore.ShopProjectUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppStore.ShopProjectUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly Basket _sessionBasket;

        public BasketController(IProductRepository productRepository, Basket basket)
        {
            _productRepository = productRepository;
            _sessionBasket = basket;   
        }
        public IActionResult Index(string returnUrl)
        {
            BasketPageViewModel basketPageViewModel = new BasketPageViewModel()
            {
                Basket = _sessionBasket,
                ReturnURL = returnUrl,
            };
            return View(basketPageViewModel);
        }
        public IActionResult AddToBasket(int productId, string returnUrl)
        {
            var product = _productRepository.GetById(productId);
            _sessionBasket.Add(product, 1);
            return RedirectToAction("Index", new {returnUrl = returnUrl});
        }
        public IActionResult RemoveFromBasket(int productId, string returnUrl)
        {
            var product = _productRepository.GetById(productId);
            _sessionBasket.Remove(product);
            return RedirectToAction("Index", new { returnUrl = returnUrl });
        }
    }
}
