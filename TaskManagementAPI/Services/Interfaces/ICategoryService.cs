using TaskManagementAPI.Models;
using TaskManagementAPI.Models.DTOs;

namespace TaskManagementAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> CreateCategory(string name);
        Task<Category> UpdateCategory(CategoryDTO categoryDTO);
        Task<Category> DeleteCategory(int id);
        Task<Category> GetCategoryById(int id);
        Task<IEnumerable<Category>> GetCategories();
    }
}
