using AppStore.Framework.Paginations;
using AppStore.Domain.Products;

namespace AppStore.ShopProjectUI.Models
{
    public class ProductListViewModel
    {
        public PagedData<Product> Data { get; set; }
        public string CurrebtCategory { get; set; }
    }
}
