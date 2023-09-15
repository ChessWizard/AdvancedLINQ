using AdvancedLINQ.Core.Entities;
using AdvancedLINQ.Core.Repositories;
using AdvancedLINQ.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AdvancedLINQDbContext _context;

        public CategoryRepository(AdvancedLINQDbContext context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _context.Categories
                .AddAsync(category);
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Categories
                .AsNoTracking();
        }

        public async Task<Category> GetAsync(Expression<Func<Category, bool>> expression)
        {
            return await GetAll()
                .FirstOrDefaultAsync(expression);
        }
    }
}
