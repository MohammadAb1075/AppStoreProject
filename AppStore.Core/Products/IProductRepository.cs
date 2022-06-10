using AppStore.Framework.Paginations;

namespace AppStore.Domain.Products
{
    public interface IProductRepository
    {
        PagedData<Product> GetAll(int pageNumber, int pageSize, string Category);
        Product GetById(int id);
    }
}
