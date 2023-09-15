using AdvancedLINQ.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Core.Repositories
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAll();

        Task<Category> GetAsync(Expression<Func<Category, bool>> expression);

        Task AddCategoryAsync(Category category);
    }
}
