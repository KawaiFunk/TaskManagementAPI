using TaskManagementAPI.Models;
using TaskManagementAPI.Models.DTOs;

namespace TaskManagementAPI.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategory(string name);
        Task<Category> UpdateCategory(CategoryDTO categoryDTO);
        Task<Category> DeleteCategory(int id);
        Task<Category> GetCategoryById(int id);
        Task<IEnumerable<Category>> GetCategories();
    }
}
