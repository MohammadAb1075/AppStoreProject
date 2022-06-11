using Microsoft.AspNetCore.Mvc;

namespace AppStore.ShopProjectUI.Controllers
{
    public class OrderContoller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
