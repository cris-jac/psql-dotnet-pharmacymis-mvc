using Microsoft.EntityFrameworkCore;
using PharmaMVC.Data;
using PharmaMVC.Interfaces;
using PharmaMVC.Models;

namespace PharmaMVC.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;
    public CategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddCategory(Category category)
    {
        _dbContext.Categories.Add(category);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteCategory(Category category)
    {
        _dbContext.Categories.Remove(category);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _dbContext.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoryById(int categoryId)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
    }

    public async Task<bool> UpdateCategory(int categoryId, Category category)
    {
        var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);

        if (existingCategory != null)
        {
            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            existingCategory.IsActive = category.IsActive;
        }
        _dbContext.Categories.Update(existingCategory);
        return await _dbContext.SaveChangesAsync() > 0;
    }
}