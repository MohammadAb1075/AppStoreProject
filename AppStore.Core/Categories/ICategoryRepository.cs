namespace AppStore.Domain.Categories
{
    public interface ICategoryRepository
    {
        List<string> GetAllCategories();
    }
}
