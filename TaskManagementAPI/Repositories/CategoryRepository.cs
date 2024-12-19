using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;
using TaskManagementAPI.Models.DTOs;
using TaskManagementAPI.Repositories.IRepositories;

namespace TaskManagementAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TasksContext _tasksContext;

        public CategoryRepository(TasksContext tasksContext)
        {
            _tasksContext = tasksContext;
        }

        public async Task<Category> CreateCategory(string name)
        {
            var category = new Category
            {
                Name = name
            };

            await _tasksContext.Categories.AddAsync(category);
            await _tasksContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var category = await _tasksContext.Categories.FirstOrDefaultAsync(c => c.ID == id);

            if (category == null)
            {
                throw new Exception("Category not found");
            }

            _tasksContext.Categories.Remove(category);
            await _tasksContext.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _tasksContext.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _tasksContext.Categories.FirstOrDefaultAsync(c => c.ID == id);

            if (category == null)
            {
                throw new Exception("Category not found");
            }

            return category;
        }

        public async Task<Category> UpdateCategory(CategoryDTO categoryDTO)
        {
            var category = await _tasksContext.Categories.FirstOrDefaultAsync(c => c.ID == categoryDTO.ID);

            if (category == null)
            {
                throw new Exception("Category not found");
            }

            category.Name = categoryDTO.Name;
            await _tasksContext.SaveChangesAsync();
            return category;
        }
    }
}
