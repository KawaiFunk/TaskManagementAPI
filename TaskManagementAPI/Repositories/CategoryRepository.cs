using TaskManagementAPI.Models;
using TaskManagementAPI.Repositories.IRepositories;

namespace TaskManagementAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
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
