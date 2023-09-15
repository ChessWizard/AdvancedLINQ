using AdvancedLINQ.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Core.Repositories
{
    public interface IMediaRepository
    {
        public Task<Media> GetAsync(Expression<Func<Media, bool>> expression);

        public IQueryable<Media> GetAll();

        Task AddMediaAsync(Media media);
    }
}
