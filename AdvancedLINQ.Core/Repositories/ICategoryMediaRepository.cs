using AdvancedLINQ.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Core.Repositories
{
    public interface ICategoryMediaRepository
    {
        Task AddCategoryMediaAsync(CategoryMedia categoryMedia);

        Task AddRangeCategoryMediaAsync(IEnumerable<CategoryMedia> categories);

        IQueryable<CategoryMedia> GetAll();
    }
}
