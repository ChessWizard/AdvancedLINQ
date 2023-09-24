using AdvancedLINQ.Core.Entities;
using AdvancedLINQ.Core.Repositories;
using AdvancedLINQ.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Data.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly AdvancedLINQDbContext _context;

        public TrackRepository(AdvancedLINQDbContext context)
        {
            _context = context;
        }

        public async Task AddRangeTrackAsync(IList<Track> tracks)
        {
            await _context.Tracks
                .AddRangeAsync(tracks);
        }
    }
}
