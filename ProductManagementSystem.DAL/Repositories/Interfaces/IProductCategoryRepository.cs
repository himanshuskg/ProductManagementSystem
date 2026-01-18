namespace ProductManagementSystem.DAL.Repositories.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task AddProductCategoryAsync(int productId, int categoryId);
        Task RemoveProductCategoryAsync(int productId, int categoryId);
    }
}
