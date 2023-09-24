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
    public class ArtistRepository : IArtistRepository
    {
        private readonly AdvancedLINQDbContext _context;

        public ArtistRepository(AdvancedLINQDbContext context)
        {
            _context = context;
        }

        public async Task AddArtistAsync(Artist artist)
        {
            await _context.Artists
                .AddAsync(artist);
        }

        public IQueryable<Artist> GetAll()
        {
            return _context.Artists
                .AsNoTracking();
        }

        public async Task<Artist> GetAsync(Expression<Func<Artist, bool>> expression)
        {
            return await _context.Artists
                    .FirstOrDefaultAsync(expression);
        }
    }
}
