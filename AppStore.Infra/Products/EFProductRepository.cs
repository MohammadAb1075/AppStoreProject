using AppStore.Domain.Products;
using AppStore.Framework.Paginations;
using AppStore.Infra.Data.Sql.Common;

namespace AppStore.Infra.Data.Sql.Products
{
    public class EFProductRepository : IProductRepository
    {
        private readonly StoreDbContext _storeDbContext;

        public EFProductRepository(StoreDbContext storeDbContext) => _storeDbContext = storeDbContext;

        public PagedData<Product> GetAll(int pageNumber, int pageSize, string Category)
        {
            var result = new PagedData<Product>
            {
                PageInfo = new PageInfo
                {
                    PageSize = pageSize,
                    PageNumber = pageNumber
                }
            };
            result.Data = _storeDbContext.Products
                                            .Where(c => string.IsNullOrEmpty(Category) || c.Category.Name == Category)
                                            .Skip((pageNumber - 1) * pageSize)
                                            .Take(pageSize)
                                            .ToList();
            result.PageInfo.TotalCount = _storeDbContext.Products
                                            .Where(c => string.IsNullOrEmpty(Category) || c.Category.Name.Equals(Category))
                                            .Count();
            return result;
        }

        public Product GetById(int id)
        {
            return _storeDbContext.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
