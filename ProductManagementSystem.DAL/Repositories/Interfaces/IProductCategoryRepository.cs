namespace ProductManagementSystem.DAL.Repositories.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task ModifyCategoriesAsync(int productId, List<int> categoryIds);
    }
}
