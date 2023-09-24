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
    public class AlbumRepository : IAlbumRepository
    {
        private readonly AdvancedLINQDbContext _context;

        public AlbumRepository(AdvancedLINQDbContext context)
        {
            _context = context;
        }

        public async Task AddAlbumAsync(Album album)
        {
            await _context.Albums
                .AddAsync(album);
        }

        public async Task AddRangeAlbumArtistAsync(IList<AlbumArtist> albumArtist)
        {
            await _context.AlbumArtists
                .AddRangeAsync(albumArtist);
        }

        public IQueryable<Album> GetAll()
        {
            return _context.Albums
                .AsNoTracking();
        }

        public async Task<Album> GetAsync(Expression<Func<Album, bool>> expression)
        {
            return await _context.Albums
                .FirstOrDefaultAsync(expression);
        }
    }
}
