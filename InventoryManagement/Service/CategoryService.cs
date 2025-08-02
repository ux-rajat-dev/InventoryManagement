using InventoryManagement.CommandModel;
using InventoryManagement.Interface;
using InventoryManagement.Models;
using InventoryManagement.QueryModel;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly InventoryDbContext _context;

        public CategoryService(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryQueryModel>> GetAllAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryQueryModel
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<CategoryQueryModel> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return null;

            return new CategoryQueryModel
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            };
        }

        public async Task<bool> CreateAsync(CategoryCommandModel model)
        {
            var category = new Category
            {
                Name = model.Name
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, CategoryCommandModel model)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            category.Name = model.Name;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
