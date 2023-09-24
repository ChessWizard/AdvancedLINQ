using AdvancedLINQ.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Core.Repositories
{
    public interface ITrackRepository
    {
        Task AddRangeTrackAsync(IList<Track> tracks);
    }
}
