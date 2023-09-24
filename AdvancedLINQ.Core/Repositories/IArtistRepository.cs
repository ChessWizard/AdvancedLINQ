using AdvancedLINQ.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Core.Repositories
{
    public interface IArtistRepository
    {
        public Task<Artist> GetAsync(Expression<Func<Artist, bool>> expression);

        public IQueryable<Artist> GetAll();

        Task AddArtistAsync(Artist artist);
    }
}
