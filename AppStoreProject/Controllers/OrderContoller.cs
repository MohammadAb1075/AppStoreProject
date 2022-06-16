using AppStore.Domain.Basket;
using AppStore.Domain.Orders;
using AppStore.ShopProjectUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppStore.ShopProjectUI.Controllers
{
    public class OrderContoller : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly Basket _basket;

        public OrderContoller(IOrderRepository orderRepository, Basket basket)
        {
            _orderRepository = orderRepository;
            _basket = basket;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel model)
        {
            if (!_basket.Items.Any())
            {
                ModelState.AddModelError("", "There Isn't Any Item In The Basket");
            }
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    Name = model.Name,
                    City = model.City,
                    Address = model.Address,
                };

                foreach (var item in _basket.Items)
                {
                    order.OrderDetails.Add(new OrderDetail
                    {
                        Product = item.Product,
                        Quantity = item.Quantity,
                });
                };

                _orderRepository.Save(order);
                _basket.Clear();
                return RedirectToAction("Complete");
            }
                return View(model);
        }

        public IActionResult Complete()
        {
            return View();
        }
    }
}
