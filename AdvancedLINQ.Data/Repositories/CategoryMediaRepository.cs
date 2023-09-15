using AdvancedLINQ.Core.Entities;
using AdvancedLINQ.Core.Repositories;
using AdvancedLINQ.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Data.Repositories
{
    public class CategoryMediaRepository : ICategoryMediaRepository
    {
        private readonly AdvancedLINQDbContext _context;

        public CategoryMediaRepository(AdvancedLINQDbContext context)
        {
            _context = context;
        }

        public async Task AddCategoryMediaAsync(CategoryMedia categoryMedia)
        {
            await _context.CategoryMedias
                .AddAsync(categoryMedia);
        }

        public async Task AddRangeCategoryMediaAsync(IEnumerable<CategoryMedia> categories)
        {
            await _context.CategoryMedias
                .AddRangeAsync(categories);  
        }

        public IQueryable<CategoryMedia> GetAll()
        {
            return _context.CategoryMedias
                .AsNoTracking();
        }
    }
}
