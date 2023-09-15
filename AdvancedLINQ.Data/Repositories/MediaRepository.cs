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
    public class MediaRepository : IMediaRepository
    {
        private readonly AdvancedLINQDbContext _context;

        public MediaRepository(AdvancedLINQDbContext context)
        {
            _context = context;
        }

        public IQueryable<Media> GetAll()
        {
            return _context.Medias
                .AsNoTracking();
        }

        public async Task<Media> GetAsync(Expression<Func<Media, bool>> expression)
        {
            return await GetAll()
                .FirstOrDefaultAsync(expression);
        }

        public async Task AddMediaAsync(Media media)
        {
            await _context.Medias
                .AddAsync(media);
        }
    }
}
