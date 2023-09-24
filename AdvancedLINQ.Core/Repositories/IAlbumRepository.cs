using AdvancedLINQ.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Core.Repositories
{
    public interface IAlbumRepository
    {
        Task<Album> GetAsync(Expression<Func<Album, bool>> expression);

        IQueryable<Album> GetAll();

        Task AddAlbumAsync(Album album);

        Task AddRangeAlbumArtistAsync(IList<AlbumArtist> albumArtist);
    }
}
