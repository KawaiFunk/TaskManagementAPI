using TaskManagementAPI.Models;
using TaskManagementAPI.Services.Interfaces;

namespace TaskManagementAPI.Services
{
    public class CategoryService : ICategoryService
    {
        public Task<Category> CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category> DeleteCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
