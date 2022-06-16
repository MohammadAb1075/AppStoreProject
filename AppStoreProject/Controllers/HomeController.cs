using AppStore.Domain.Products;
using AppStore.ShopProjectUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppStoreProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProductRepository _productRepository;
        private readonly int pageSize = 2;

        public HomeController(IProductRepository productRepository)
        {   
            _productRepository = productRepository;
        }

        public IActionResult Index(string category = "", int pageNumber = 1)
        {
            var viewModel = new ProductListViewModel
            {
                CurrebtCategory = category,
                Data = _productRepository.GetAll(pageNumber, pageSize, category)
        };
            return View(viewModel);
        }
    }
}