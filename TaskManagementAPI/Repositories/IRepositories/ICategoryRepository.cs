using TaskManagementAPI.Models;

namespace TaskManagementAPI.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<Category> DeleteCategory(Guid id);
        Task<Category> GetCategoryById(Guid id);
        Task<IEnumerable<Category>> GetCategories();
    }
}
