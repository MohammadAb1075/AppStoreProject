using AppStore.Domain.Categories;
using AppStore.Infra.Data.Sql.Common;

namespace AppStore.Infra.Data.Sql.Categories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _storeDbContext;
        public EFCategoryRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public List<string> GetAllCategories() => _storeDbContext.Categories.Select(c => c.Name).ToList();
    }
}
