using AppStore.Domain.Categories;
using Microsoft.AspNetCore.Mvc;

namespace AppStore.ShopProjectUI.Components
{
    public class CategorySideBoxViewComponent: ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategorySideBoxViewComponent(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;   
        }
        public IViewComponentResult Invoke()
        {
            var currentCategory = RouteData?.Values["Category"];
            ViewData["Category"] = currentCategory;
            return View(_categoryRepository.GetAllCategories());
        }
    }
}
