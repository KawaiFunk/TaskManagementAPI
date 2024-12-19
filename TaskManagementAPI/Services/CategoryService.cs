using TaskManagementAPI.Models;
using TaskManagementAPI.Models.DTOs;
using TaskManagementAPI.Repositories;
using TaskManagementAPI.Repositories.IRepositories;
using TaskManagementAPI.Services.Interfaces;

namespace TaskManagementAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<Category> CreateCategory(string name)
        {
            var createdCategory = _categoryRepository.CreateCategory(name);
            return createdCategory;
        }

        public Task<Category> DeleteCategory(int id)
        {
            var deletedCategory = _categoryRepository.DeleteCategory(id);
            return deletedCategory;
        }

        public Task<IEnumerable<Category>> GetCategories()
        {
            var categories = _categoryRepository.GetCategories();
            return categories;
        }

        public Task<Category> GetCategoryById(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            return category;
        }

        public Task<Category> UpdateCategory(CategoryDTO categoryDTO)
        {
            var updatedCategory = _categoryRepository.UpdateCategory(categoryDTO);
            return updatedCategory;
        }
    }
}
