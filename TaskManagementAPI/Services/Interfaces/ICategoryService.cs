using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> CreateCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<Category> DeleteCategory(Guid id);
        Task<Category> GetCategoryById(Guid id);
        Task<IEnumerable<Category>> GetCategories();
    }
}
