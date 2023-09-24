using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Service.CQRS.Queries.GetAlbumById
{
    public class GetAlbumByIdQueryResult
    {
        public string Title { get; set; }

        public int TrackCount { get; set; }

        public TimeSpan TotalDuration { get; set; }

        public DateTimeOffset ReleaseDate { get; set; }

        public string AlbumType { get; set; }

        public string ImageUrl { get; set; }

        public List<TrackResult> Tracks { get; set; }
    }

    public class TrackResult
    {
        public string Title { get; set; }

        public string Owners { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
